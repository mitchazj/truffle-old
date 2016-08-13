using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blacksink.Blackboard;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;

namespace Blacksink
{
    public class MainContext : ApplicationContext
    {
        #region Crucial Variables
        //For the task tray icon.
        NotifyIcon main_icon = new NotifyIcon();
        //For the crawling :P
        Crawler crawler = new Crawler();
        //Check if it's time to update.
        Timer tm_refresh = new Timer() { Interval = 1000 * 60 };

        bool is_crawling = false;
        bool connectivity_issues = false;
        bool login_issues = false;
        bool first_time = false;

        //Registry stuff for auto-starting
        private const string RegistryPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string KeyName = "TruffleMITCH";
        bool isRunningOnLogin;
        #endregion

        /// <summary>
        /// Gets this whole application rolling
        /// </summary>
        public MainContext() {
            setupIcon();

            if (!Properties.Settings.Default.is_setup) {
                first_time = true; //To cache this - it's changed in the Setup form.
                frmSetup frm = new frmSetup();
                frm.OnSetupFinished += setupCompleted;
                frm.Show();
            }

#if DEBUG
            //Nothin'
#else
            //Load registry value
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(RegistryPath, true);
            isRunningOnLogin = (rk.GetValue(KeyName) != null);
            if (!isRunningOnLogin)
                rk.SetValue(KeyName, Application.ExecutablePath);
#endif

            try {
                GlobalVariables.Units = JsonConvert.DeserializeObject<List<Unit>>(Properties.Settings.Default.UnitData);
                if (GlobalVariables.Units == null)
                    GlobalVariables.Units = new List<Unit>();
                //Debugging
                //else {
                //    foreach (Unit u in GlobalVariables.Units) {
                //        Console.WriteLine(u.Name);
                //        foreach (BlackboardFile f in u.Files) {
                //            Console.WriteLine(f.RawURL);
                //        }
                //    }
                //}
            } catch {
                GlobalVariables.Units = new List<Unit>();
            }

            crawler.OnSyncCompleted += Crawler_OnSyncCompleted;
            crawler.OnLoginProblem += Crawler_OnLoginProblem;
            crawler.OnLoginSuccess += Crawler_OnLoginSuccess;
            crawler.OnConnectivityProblem += Crawler_OnConnectivityProblem;
            crawler.OnCrawlingEvent += Crawler_OnCrawlingEvent;

            tm_refresh.Tick += tm_refresh_Tick;
            //tm_refresh_Tick(tm_refresh, new EventArgs()); //Fire the first event
            tm_refresh.Start();
        }

        private void setupCompleted(object sender, EventArgs e) {
            if (first_time) {
                first_time = false;
                main_icon.ShowBalloonTip(5000, "Truffle will continue to run in the background", "We'll let you know when the new files have downloaded.", ToolTipIcon.Info);
                tm_refresh_Tick(tm_refresh, new EventArgs()); //Start our first sync
            } else {
                login_issues = false; //Successful setup = correct login details :-)
                main_icon.ShowBalloonTip(5000, "Success!", "We've updated your Truffle settings.", ToolTipIcon.Info);
                tm_refresh_Tick(tm_refresh, new EventArgs()); //Just in case
            }
        }

        private void Crawler_OnSyncCompleted(object sender, EventArgs e) {
            Console.WriteLine("[Received] Sync Completed");
            if (!login_issues && !connectivity_issues) {
                Console.WriteLine("[Received][Passed] Sync Completed");
                if (GlobalVariables.FilesDownloaded != 0)
                    main_icon.ShowBalloonTip(5000, "Sync Completed", string.Format("{0} new files have been downloaded.", GlobalVariables.FilesDownloaded), ToolTipIcon.Info);
                main_icon.Icon = icon.mug_ok;
                Properties.Settings.Default.LastSyncTime = DateTime.Now;
                Properties.Settings.Default.Save();
                main_icon.Text = "Truffle\r\nLast Synchronized " + Properties.Settings.Default.LastSyncTime.ToString("t");
                is_crawling = false;
                Application.DoEvents();
            }
        }

        private void Crawler_OnCrawlingEvent(object sender, EventArgs e) {
            main_icon.Icon = icon.mug_sync;
            main_icon.Text = "Blackboard Sync in Progress...";
            is_crawling = true;
        }

        private void Crawler_OnConnectivityProblem(object sender, EventArgs e) {
            Console.WriteLine("[Received] Internet Problem");
            main_icon.Icon = icon.mug_error;
            main_icon.Text = "Truffle\r\nNo Internet Connection";
            connectivity_issues = true;
            is_crawling = false;
            Application.DoEvents();
        }

        private void Crawler_OnLoginProblem(object sender, EventArgs e) {
            Console.WriteLine("[Received] Login Problem");
            main_icon.Icon = icon.mug_error;
            main_icon.Text = "Truffle\r\nLogin Problem - Please Update Your Password.";
            login_issues = true;
            is_crawling = false;
            Application.DoEvents();
        }

        private void Crawler_OnLoginSuccess(object sender, EventArgs e) {
            login_issues = false;
            if (login_issues && !is_crawling) {
                //Basically, there were login issues, but they've been resolved now.
                Console.WriteLine("Login Success - right here");
                main_icon.Icon = icon.mug_ok;
                main_icon.Text = "Truffle\r\nLast Synchronized " + Properties.Settings.Default.LastSyncTime.ToString("t");
                Application.DoEvents();
            }
        }

        #region Overrides
        protected override void ExitThreadCore() {
            main_icon.Visible = false;
            main_icon.Dispose();
            crawler.Dispose();
            tm_refresh.Stop();
            tm_refresh.Dispose();
            base.ExitThreadCore();
        }
        #endregion

        #region Refreshing
        private void tm_refresh_Tick(object sender, EventArgs e) {
            bool active = Properties.Settings.Default.is_setup;
            if (InternetConnectivity.checkInternet()) {
                tm_refresh.Interval = 1000 * 60;
                if (connectivity_issues && !is_crawling) {
                    main_icon.Icon = icon.mug_ok;
                    main_icon.Text = "Truffle\r\nLast Synchronized " + Properties.Settings.Default.LastSyncTime.ToString("t");
                    Application.DoEvents();
                }
                connectivity_issues = false;
            } else {
                tm_refresh.Interval = 1000 * 15;
                main_icon.Icon = icon.mug_error;
                main_icon.Text = "Truffle\r\nNo Internet Connection";
                connectivity_issues = true;
                is_crawling = false;
                Application.DoEvents();
            }

            if (!is_crawling && active && (DateTime.Now - Properties.Settings.Default.LastSyncTime).TotalMilliseconds > 1000 * 60 * 60 * 3 /*3 hours*/) {
                Console.WriteLine("Sync started fromm here.");
                Sync();
            }
        }
        #endregion

        #region Other Voids
        /// <summary>
        /// Places the Black-Sink icon in the Windows Task Tray
        /// </summary>
        private void setupIcon() {
            main_icon.Text = "Truffle";
            main_icon.Icon = icon.mug_ok;
            main_icon.ContextMenu = new ContextMenu();
            main_icon.ContextMenu.MenuItems.Add("Open units in File Explorer...", onOpenUnitsClicked);
            main_icon.ContextMenu.MenuItems.Add("-");
            main_icon.ContextMenu.MenuItems.Add("Setup wizard...", onSetupWizardClicked);
            main_icon.ContextMenu.MenuItems.Add("About...", onAboutClicked);
            main_icon.ContextMenu.MenuItems.Add("-");
            main_icon.ContextMenu.MenuItems.Add("Sync Now", onSyncNowClicked);
            main_icon.ContextMenu.MenuItems.Add("-");
            main_icon.ContextMenu.MenuItems.Add("Quit", onQuitClicked);
            main_icon.BalloonTipClicked += Main_icon_BalloonTipClicked;

            main_icon.Visible = true;
        }

        private void Main_icon_BalloonTipClicked(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(Properties.Settings.Default.StorageLocation);
        }

        /// <summary>
        /// Spiders new content from Blackboard.
        /// </summary>
        public void Sync() {
            Console.WriteLine("Sync called.");
            if (!is_crawling && !connectivity_issues && !login_issues) {
                try {
                    Console.WriteLine("Sync starting - passed.");
                    main_icon.Icon = icon.mug_sync;
                    main_icon.Text = "Blackboard Sync in Progress...";
                    is_crawling = true;
                    crawler.Crawl();
                } catch {
                    //I once had an unreproducible error here. This code is for safeguarding :P
                    main_icon.Icon = icon.mug_error;
                    main_icon.Text = "Temporary Configuration Problem";
                    is_crawling = false;
                }
            } else {
                Console.WriteLine("Sync rejected due to unresolved issues. Scanner has not been started.");
            }
        }
        #endregion

        #region Event Handlers
        private void onQuitClicked(object sender, EventArgs e) {
            this.ExitThreadCore();
        }
        private void onAboutClicked(object sender, EventArgs e) {
            frmAbout frm = new frmAbout();
            frm.Show();
        }
        private void onOpenUnitsClicked(object sender, EventArgs e) {
            if (Properties.Settings.Default.StorageLocation != null && Properties.Settings.Default.StorageLocation != "" && Directory.Exists(Properties.Settings.Default.StorageLocation))
                System.Diagnostics.Process.Start(Properties.Settings.Default.StorageLocation);
            else
                MessageBox.Show("Storage location unavailable. Have you run the setup wizard?");
        }
        private void onSyncNowClicked(object sender, EventArgs e) {
            Application.DoEvents();
            if (Properties.Settings.Default.is_setup)
                Sync();
            else
                MessageBox.Show("Truffle isn't connected to your Blackboard account. Have you run the setup wizard?");
        }
        private void onSetupWizardClicked(object sender, EventArgs e) {
            frmSetup frm = new frmSetup();
            frm.OnSetupFinished += setupCompleted;
            frm.Show();
        }
        #endregion
    }
}
