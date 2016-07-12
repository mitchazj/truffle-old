using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System.Threading;

namespace Blacksink.Blackboard
{
    public class Crawler : Control
    {
        #region Crawling Stuff
        private ChromiumWebBrowser b_root = null;
        string js_inject = "";

        Thread crawler;
        List<CrawlableURL> urls = new List<CrawlableURL>();
        List<string> crawled_urls = new List<string>();
        bool crawl_started = false, safe_to_continue = true;

        DateTime crawl_start;
        DownloadHandler d_handler;
        public string current_unitcode = "";
        public string current_page = "";

        int potentialLoginFails = 0;
        const int potentialLoginFailsThreshold = 10;
        #endregion

        #region Events
        private delegate void OnCrawlRequestHandler(string url);
        private OnCrawlRequestHandler OnCrawlRequest;
        private delegate void OnPageInjectHandler(bool is_specialConsideration);
        private OnPageInjectHandler OnPageInject;
        public delegate void OnSyncCompletedHandler(object sender, EventArgs e);
        public event OnSyncCompletedHandler OnSyncCompleted;
        public delegate void OnLoginSuccessHandler(object sender, EventArgs e);
        public event OnLoginSuccessHandler OnLoginSuccess;
        public delegate void OnLoginProblemHandler(object sender, EventArgs e);
        public event OnLoginProblemHandler OnLoginProblem;
        public delegate void OnConnectivityProblemHandler(object sender, EventArgs e);
        public event OnConnectivityProblemHandler OnConnectivityProblem;
        #endregion

        #region Constructor
        public Crawler() {
            OnPageInject = ThreadSafePageInject;
            OnCrawlRequest = ThreadSafeCrawlRequest;

            d_handler = new DownloadHandler();
            d_handler.DownloadHandled += D_handler_DownloadHandled;

            //Initialize the off-screen browser for crawling
            b_root = new ChromiumWebBrowser("empty");
            b_root.BrowserSettings.ApplicationCache = CefState.Disabled; //Caching occasionally causes the crawler to miss new files
            b_root.BrowserSettings.ImageLoading = CefState.Disabled; //We don't want to waste our time/data with pictures :D
            b_root.DownloadHandler = d_handler;
            b_root.JsDialogHandler = new JsDialogHandler();
            b_root.FrameLoadEnd += b_root_FrameLoadEnd; //This allows us to inject JS in a timely manner
            OnSyncCompleted += Crawler_OnSyncCompleted;

            this.CreateHandle();
            Application.DoEvents();
        }
        #endregion

        #region Destructor :P
        protected override void Dispose(bool disposing) {
            if (crawler != null) {
                try {
                    crawler.Abort();
                } catch { }
            }
            b_root.Dispose();
            Cef.Shutdown();

            base.Dispose(disposing);
        }
        #endregion

        #region Private Event Handlers

        private void Crawler_OnSyncCompleted(object sender, EventArgs e) {
            //TODO: do something
            Application.DoEvents();
            Properties.Settings.Default.UnitData = JsonConvert.SerializeObject(GlobalVariables.Units);
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Whenever b_root finishes loading a page, we inject our JS.
        /// </summary>
        private void b_root_FrameLoadEnd(object sender, FrameLoadEndEventArgs e) {
            if (InternetConnectivity.IsConnectionAvailable()) {
                ThreadSafePageInject(isSpecialConsideration(e.Url));
            } else {
                if (OnConnectivityProblem != null)
                    OnConnectivityProblem(new object(), new EventArgs());
            }
        }

        /// <summary>
        /// File download has begun and will complete in due time. We can keep crawling now.
        /// </summary>
        private void D_handler_DownloadHandled(object sender, EventArgs e) {
            safe_to_continue = true;
        }

        #endregion

        #region Crawling Controllers
        /// <summary>
        /// Begins a generic crawl after refreshing the username and password.
        /// If the username and pasword are empty, an exception is thrown.
        /// </summary>
        public void Crawl() {
            string username = Security.DecryptString(Properties.Settings.Default.StudentNumber);
            string password = Security.DecryptString(Properties.Settings.Default.StudentPassword);
            if (username != "" && password != "") {
                //Create our personalized injection script
                js_inject = Script.getScript(username, password);

                //Reset variables
                urls.Clear();
                crawled_urls.Clear();
                crawl_started = false;

                //Begin crawl.
                ThreadSafeCrawlRequest("http://blackboard.qut.edu.au/");
            } else {
                throw new Exception("Empty Username and/or Password.");
            }
        }

        /// <summary>
        /// Navigates b_root to the specified URL.
        /// </summary>
        /// <param name="url">The URL to load</param>
        public void ThreadSafeCrawlRequest(string url) {
            if (!InvokeRequired) {
                //Console.WriteLine("[* Crawling] " + url);
                b_root.Load(url); //We're loading the URL now. Next stop: JS injection when the page is fully loaded.
            }
            else
                this.Invoke(OnCrawlRequest, url);
        }

        /// <summary>
        /// Call this void to initiate/continue the syncing thread.
        /// </summary>
        private void Continue() {
            if (!crawl_started) {
                GlobalVariables.FilesDownloaded = 0;
                GlobalVariables.FilesSkipped = 0;
                crawl_started = true;
                crawler = new Thread(Follow);
                crawler.Start();
                crawl_start = DateTime.Now;
            }
            else {
                safe_to_continue = true;
            }
        }

        /// <summary>
        /// This is the working method of the syncing thread.
        /// As soon as this method completes, the sync is finished.
        /// </summary>
        private void Follow() {
            //As long as there are unscanned URLs, keep crawling.
            while (urls.Count > 0) {
                //Get the URL at index 0 and work with it.
                CrawlableURL curl = urls[0];
                string url = curl.URL;
                url = url.Contains("http") ? url : "https://blackboard.qut.edu.au/" + url;

                //Remove it, allowing the next URL in the list to fall into place for next time.
                urls.RemoveAt(0);

                //Make sure we don't unnecessarily re-crawl URLs.
                if (!crawled_urls.Contains(url) && !Unit.IsFilePreviouslyDownloaded(url)) {
                    //Update context for this page
                    current_unitcode = curl.UnitCode;
                    GlobalVariables.CurrentUnitCode = current_unitcode;
                    GlobalVariables.CurrentUrl = url;
                    current_page = url;

                    //Load this URL and extract data
                    ThreadSafeCrawlRequest(url);

                    //Mark this URL as crawled.
                    crawled_urls.Add(url);

                    //Wait for "Continue()"
                    safe_to_continue = false;
                    while (!safe_to_continue)
                        Thread.Sleep(100);
                } else {
                    //Console.WriteLine("[Skipped] : " + url);
                }
            }

            //We've finished crawling Blackboard. High fives all round.
            this.Invoke(OnSyncCompleted, new object(), new EventArgs());
            Console.WriteLine("[* Completed] " + crawled_urls.Count + " pages crawled in " + (DateTime.Now - crawl_start).TotalMinutes + " minutes");
        }

        #endregion

        #region Inject Controllers

        /// <summary>
        /// Thread-safe JS injection
        /// </summary>
        /// <param name="specialConsideration">True if we are curently on a Special Consideration file.</param>
        public void ThreadSafePageInject(bool specialConsideration) {
            if (!InvokeRequired) {
                if (!specialConsideration)
                    Inject(b_root);
                else
                    specialConsiderationInject(b_root);
            }
            else
                this.Invoke(OnPageInject, specialConsideration);
        }

        /// <summary>
        /// Injects the Javascript code and processes the result.
        /// </summary>
        /// <param name="b">The ChromimumWebBrowser to inject into.</param>
        private void Inject(ChromiumWebBrowser b) {
            var task = b.EvaluateScriptAsync(js_inject);
            task.ContinueWith(t => {
                if (!t.IsFaulted) {
                    var response = t.Result;
                    if (response.Success == true && response.Result != null) {
                        var result = response.Result.ToString();
                        if (result != string.Empty && result != "null" && result != "login successful" && result != "login unsuccessful") {
                            potentialLoginFails = 0; //No need to worry :-)
                            OnLoginSuccess?.Invoke(new object(), new EventArgs()); //Tell the main class it's all good
                            Dictionary<string, string> conversion = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                            foreach (var pair in conversion) {
                                int dummy = 0;
                                if (int.TryParse(pair.Key, out dummy)) {
                                    urls.Add(new CrawlableURL(current_unitcode, pair.Value));
                                    //Console.WriteLine("[* Discovered] [" + current_unitcode + "] " + pair.Value);
                                }
                                else {
                                    string u_code = pair.Key.Substring(0, 6);
                                    urls.Add(new CrawlableURL(u_code, pair.Value));
                                    Unit.EnsureExists(new Unit(u_code, pair.Value));
                                    //Console.WriteLine("[* Discovered] [" + pair.Key.Substring(0, 6) + "] " + pair.Value);
                                }
                            }
                            if (urls.Count > 0)
                                Continue();
                        } else if (result == "login successful" || result == "login unsuccessful") {
                            ++potentialLoginFails;
                            if (potentialLoginFails > potentialLoginFailsThreshold) {
                                //We might have a problem xD
                                potentialLoginFails = 0;

                                //Clear the rest of the work, fail gracefully
                                urls.Clear();
                                if (OnLoginProblem != null)
                                    OnLoginProblem(new object(), new EventArgs());
                            }
                        }
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Forces Special Consideration files to download immediately after they open in Adobe's chrome plugin.
        /// Ideally, I would disable the plugin - but for some reason doing this caused CefSharp to stall.
        /// If any CefSharp experts figure out a cleaner way to do this, let me know.
        /// </summary>
        /// <param name="b">The browser to inject into</param>
        private void specialConsiderationInject(ChromiumWebBrowser b) {
            string code = "document.body.innerHTML = \"<a id='d_link' href='" + current_page + "' download>Clickity</a>\"; document.querySelector('#d_link').click();";
            var task = b.EvaluateScriptAsync(code);
            task.ContinueWith(t => {
                //For debug ouput when testing
                if (!t.IsFaulted) {
                    //Console.WriteLine("Special Consideration @ " + current_page);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion

        #region Special Consideration Files
        private bool isSpecialConsideration(string url) {
            url = url.ToLower();
            return url.EndsWith(".pdf") || url.EndsWith(".png") || url.EndsWith(".jpeg") || url.EndsWith(".jpg")
                || url.EndsWith(".m3p") || url.EndsWith(".mp3") || url.EndsWith(".mp4") || url.EndsWith(".wav")
                || url.EndsWith(".flac") || url.EndsWith(".midi");
        }
        #endregion
    }
}
