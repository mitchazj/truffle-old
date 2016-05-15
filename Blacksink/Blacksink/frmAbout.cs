using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blacksink
{
    public partial class frmAbout : Form
    {
        public frmAbout() {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void lbAbout_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://www.mitchellazj.com/app-ref.php?id=1");
        }

        private void label2_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://www.mitchellazj.com/app-ref.php?id=2");
        }
    }
}
