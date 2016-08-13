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

        public frmMain() {
            InitializeComponent();
            main_GUI = new ChromiumWebBrowser("http://localhost:61210/");
            this.Controls.Add(main_GUI);
        }
    }
}
