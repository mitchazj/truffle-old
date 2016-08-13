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
            main_GUI.MouseDown += Main_GUI_MouseDown;
            pnMain.Controls.Add(main_GUI);
        }

        private void Main_GUI_MouseDown(object sender, MouseEventArgs e) {
            if (e.Location.Y < 45) {
                MessageBox.Show("Test Successful");
            }
        }
    }
}
