using Newtonsoft.Json;
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
    public partial class frmUnitExplorer : Form
    {
        public frmUnitExplorer() {
            InitializeComponent();

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
            }
            catch {
                GlobalVariables.Units = new List<Unit>();
            }

            Load();
        }

        private void Load() {
            foreach (Unit u in GlobalVariables.Units) {
                listBox1.Items.Add(u.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            textBox1.Text = "";
            foreach (BlackboardFile f in GlobalVariables.Units[listBox1.SelectedIndex].Files) {
                string description = string.Format("Name: {0}\r\nURL: {1}\r\nRaw URL: {2}\r\nLocal Path: {3}\r\nFirst Downloaded: {4}\r\nLast Downloaded: {5}\r\nTimes Downloaded: {6}\r\n\r\n", f.Name, f.URL, f.RawURL, f.LocalPath, f.FirstDownloaded, f.LastDownloaded, f.TimesDownloaded);
                textBox1.Text += description;
            }
        }
    }
}
