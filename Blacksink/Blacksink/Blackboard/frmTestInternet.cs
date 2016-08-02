using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blacksink.Blackboard
{
    public partial class frmTestInternet : Form
    {
        Timer tm = new Timer() { Interval = 1000 * 2 };

        public frmTestInternet() {
            InitializeComponent();
            tm.Tick += Tm_Tick;
            tm.Start();
        }

        private void Tm_Tick(object sender, EventArgs e) {
            //textBox1.Text += InternetConnectivity.strongInternetConnectionTest() ? "Working!\r\n" : "NOT WORKING!!!!!!!!!\r\n";
            textBox1.Text += InternetConnectivity.checkInternet() ? "Working!\r\n" : "NOT WORKING!!!!!!!!!\r\n";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            Blackboard.InternetConnectivity.isInternetWorkingTestVar = checkBox1.Checked;
        }
    }
}
