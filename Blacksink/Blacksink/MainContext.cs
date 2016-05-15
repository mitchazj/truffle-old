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

        //Registry stuff for auto-starting
        private const string RegistryPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string KeyName = "Black-Sink";
        bool isRunningOnLogin;
        #endregion

        /// <summary>
        /// Gets this whole application rolling
        /// </summary>
        public MainContext() {
            setupIcon();

            if (!Properties.Settings.Default.is_setup) {
                frmSetup frm = new frmSetup();
                frm.OnSetupFinished += setupCompleted;
                frm.Show();
            }

            //Load registry value
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(RegistryPath, true);
            isRunningOnLogin = (rk.GetValue(KeyName) != null);
            if (!isRunningOnLogin)
                rk.SetValue(KeyName, Application.ExecutablePath);

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

            tm_refresh.Tick += tm_refresh_Tick;
            tm_refresh_Tick(tm_refresh, new EventArgs()); //Fire the first event
            tm_refresh.Start();
        }

        private void setupCompleted(object sender, EventArgs e) {
            main_icon.ShowBalloonTip(5000, "Black-Sink will continue to run in the background", "We'll let you know when the new files have downloaded.", ToolTipIcon.Info);
            tm_refresh_Tick(tm_refresh, new EventArgs()); //Start our first sync
        }

        private void Crawler_OnSyncCompleted(object sender, EventArgs e) {
            if (GlobalVariables.FilesDownloaded != 0)
                main_icon.ShowBalloonTip(5000, "Sync Completed", string.Format("{0} new files have been downloaded.", GlobalVariables.FilesDownloaded), ToolTipIcon.Info);
            main_icon.Icon = icon.black_sink_ok;
            is_crawling = false;
            Application.DoEvents();
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
            if (!is_crawling && active && (DateTime.Now - Properties.Settings.Default.LastSyncTime).TotalMilliseconds > 1000 * 60 * 60 * 3 /*3 hours*/) {
                Sync();
            }
        }
        #endregion

        #region Other Voids
        /// <summary>
        /// Places the Black-Sink icon in the Windows Task Tray
        /// </summary>
        private void setupIcon() {
            main_icon.Text = "Black-Sink";
            main_icon.Icon = icon.black_sink_ok;
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
            if (!is_crawling) {
                Properties.Settings.Default.LastSyncTime = DateTime.Now;
                Properties.Settings.Default.Save();
                main_icon.Icon = icon.black_sink_sync;
                main_icon.Text = "Blackboard Sync in Progress...";
                is_crawling = true;
                crawler.Crawl();
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
            Sync();
        }
        private void onSetupWizardClicked(object sender, EventArgs e) {
            frmSetup frm = new frmSetup();
            frm.OnSetupFinished += setupCompleted;
            frm.Show();
        }
        #endregion
    }
}
