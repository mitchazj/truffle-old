using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;

namespace Blacksink
{
    public partial class frmMain : Form {
        private ChromiumWebBrowser main_GUI;
        private bool shutdown = false;

        public frmMain() {
            InitializeComponent();
            main_GUI = new ChromiumWebBrowser(Application.StartupPath + "\\HTML\\testing.html");
            pnMain.Controls.Add(main_GUI);
        }

        public frmMain(ServiceAdaptor adaptor) {
            InitializeComponent();
            main_GUI = new ChromiumWebBrowser(Application.StartupPath + "\\HTML\\testing.html");
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
