using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksink.Blackboard
{
    public static class GlobalVariables
    {
        public static List<Unit> Units { get; set; }

        public static string CurrentUnitCode { get; set; }
        public static string CurrentUnitFolder { get; set; }
        public static string CurrentUrl { get; set; }
        public static int FilesDownloaded = 0;
        public static int FilesSkipped = 0;
    }

    public class DownloadHandler : IDownloadHandler
    {
        public delegate void OnDownloadHandled(object sender, EventArgs e);
        public event OnDownloadHandled DownloadHandled;

        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback) {
            if (!callback.IsDisposed) {
                using (callback) {
                    string directory = Properties.Settings.Default.StorageLocation + (GlobalVariables.CurrentUnitCode != "" ? GlobalVariables.CurrentUnitCode + "/" : "");
                    Directory.CreateDirectory(directory);

                    string filename = directory + downloadItem.SuggestedFileName;
                    if (!File.Exists(filename)) {
                        callback.Continue(filename, showDialog: false);
                        ++GlobalVariables.FilesDownloaded;

                        BlackboardFile f = new BlackboardFile(downloadItem.SuggestedFileName, downloadItem.Url);
                        f.RawURL = GlobalVariables.CurrentUrl;
                        f.FirstDownloaded = DateTime.Now;
                        f.LastDownloaded = DateTime.Now;
                        f.TimesDownloaded = 1;
                        f.LocalPath = filename;

                        //We know the unit we want exists in GlobalVariables.Units because it was created before the download started, back in Crawler.cs
                        GlobalVariables.Units.First(u => u.Name == GlobalVariables.CurrentUnitCode).Files.Add(f);
                    }
                    else {
                        //FUTURE FEATURE: Allow files to be marked for redownloading.
                        ++GlobalVariables.FilesSkipped;

                        if (!Unit.IsFilePreviouslyDownloaded(GlobalVariables.CurrentUrl)) {
                            //Whoops. Might be from a previous release
                            BlackboardFile f = new BlackboardFile(downloadItem.SuggestedFileName, downloadItem.Url);
                            f.RawURL = GlobalVariables.CurrentUrl;
                            f.FirstDownloaded = DateTime.Now;
                            f.LastDownloaded = DateTime.Now;
                            f.TimesDownloaded = 1;
                            f.LocalPath = filename;

                            //We know the unit we want exists in GlobalVariables.Units because it was created before the download started, back in Crawler.cs
                            GlobalVariables.Units.First(u => u.Name == GlobalVariables.CurrentUnitCode).Files.Add(f);
                        }
                    }

                    if (DownloadHandled != null)
                        DownloadHandled(new object(), new EventArgs());
                }
            }
        }

        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback) { }
    }
}
