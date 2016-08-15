using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace Blacksink
{
    public partial class frmMain : Form {
        private ChromiumWebBrowser main_GUI;
        private bool shutdown = false;

        public frmMain() {
            InitializeComponent();
            //For testing purposes.
            main_GUI = new ChromiumWebBrowser(Application.StartupPath + "\\HTML\\testing.html");
            pnMain.Controls.Add(main_GUI);
        }

        /// <summary>
        /// The main constructor for this class
        /// </summary>
        /// <param name="adaptor"></param>
        public frmMain(ServiceAdaptor adaptor) {
            InitializeComponent();
            main_GUI = new ChromiumWebBrowser(Application.StartupPath + "\\HTML\\testing.html");
            main_GUI.BrowserSettings.ApplicationCache = CefState.Disabled;
            main_GUI.RegisterJsObject("truffleService", adaptor);
            pnMain.Controls.Add(main_GUI);
        }

        public void PrepareShutdown() {
            shutdown = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            e.Cancel = !shutdown;
            this.Hide();
            base.OnFormClosing(e);
        }
    }
}
