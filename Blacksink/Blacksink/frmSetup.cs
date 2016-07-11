using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blacksink.Blackboard;
using CefSharp.OffScreen;
using CefSharp;
using Newtonsoft.Json;
using System.IO;

namespace Blacksink
{
    public partial class frmSetup : Form
    {
        int Wizard_Position = 0;
        const string URL = "https://esoe.qut.edu.au/qut-login/";
        private ChromiumWebBrowser b_login = null;
        private delegate void OnActHandler(bool success);
        private OnActHandler OnAct;
        bool page_loaded = false;
        bool has_injected = false;
        bool first_step_passed = false;
        int failed_passes = 0;
        string js_inject = "";

        public delegate void OnSetupFinishedHandler(object sender, EventArgs e);
        public event OnSetupFinishedHandler OnSetupFinished;

        public frmSetup() {
            InitializeComponent();
            b_login = new ChromiumWebBrowser(URL);
            b_login.FrameLoadEnd += B_login_FrameLoadEnd;
            OnAct = Act;
        }

        private void Next() {
            if (Wizard_Position == 0) {
                ++Wizard_Position;
                pnContain.Visible = false;
                pnConnecting.Visible = true;
                btnNext.Enabled = false;
                Login();
            }
            else if (Wizard_Position == 1) {
                ++Wizard_Position;
                pnConnecting.Visible = false;
                pnFileLocation.Visible = true;
                btnNext.Enabled = true;
                btnNext.Text = "Finish";
                try {
                    if (Properties.Settings.Default.StorageLocation != "") {
                        txLocation.Text = Properties.Settings.Default.StorageLocation;
                    } else {
                        txLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Blacksink\\QUT\\Units\\";
                    }
                }
                catch { txLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Blacksink\\QUT\\Units\\"; }
            }
            else if (Wizard_Position == 2) {
                try {
                    Directory.CreateDirectory(txLocation.Text);
                } catch {
                    MessageBox.Show("Invalid folder path, or permission to access was denied.");
                    return;
                }
                if (Directory.GetFiles(txLocation.Text).Length == 0 && Directory.GetDirectories(txLocation.Text).Length == 0) {
                    //We are done! Save our configuration to settings
                    string location = txLocation.Text.Replace("\\", "/");
                    Properties.Settings.Default.StorageLocation = txLocation.Text.EndsWith("\\") ? txLocation.Text : txLocation.Text + "\\";
                    Properties.Settings.Default.StudentNumber = Security.EncryptString(textBox1.Text);
                    Properties.Settings.Default.StudentPassword = Security.EncryptString(textBox2.Text);
                    Properties.Settings.Default.is_setup = true;
                    Properties.Settings.Default.Save();

                    //Call the event handler
                    if (OnSetupFinished != null)
                        OnSetupFinished(new object(), new EventArgs());

                    //Mic drop
                    this.Close();
                } else {
                    MessageBox.Show("Selected folder must be empty.");
                }
            }
        }

        private void BackToStart() {
            Wizard_Position = 0;
            failed_passes = 0;
            page_loaded = false;
            has_injected = false;
            first_step_passed = false;
            js_inject = "";
            b_login.Load(URL);
            pnContain.Visible = true;
            pnConnecting.Visible = false;
            pnFileLocation.Visible = false;
            btnNext.Enabled = true;
            btnNext.Text = "Next";
        }

        private void Act(bool success) {
            if (success)
                Next();
            else
                BackToStart();
        }

        private void Inject() {
            var task = b_login.EvaluateScriptAsync(js_inject);
            Application.DoEvents();
            task.ContinueWith(t => {
                if (!t.IsFaulted) {
                    var response = t.Result;
                    if (response.Success == true && response.Result != null) {
                        var result = response.Result.ToString();
                        if (!first_step_passed) {
                            if (result == "login successful") {
                                //Awesome! We're in.
                                Application.DoEvents();
                                first_step_passed = true;
                            }
                            else {
                                //Bother. There was an error inputting information.
                                Application.DoEvents();
                                MessageBox.Show("Could not connect to Blackboard.");
                                this.Invoke(OnAct, false);
                            }
                        } else {
                            Application.DoEvents();
                            ++failed_passes;
                            if (failed_passes == 2) {
                                if (result == "login successful" || result == "login unsuccessful") {
                                    //Uh-oh. We should be well past this stage. Abort, abort!
                                    Application.DoEvents();
                                    MessageBox.Show("Invalid Username/Password");
                                    this.Invoke(OnAct, false);
                                }
                                else {
                                    //Success! Moving right along to the next slide.
                                    Application.DoEvents();
                                    this.Invoke(OnAct, true);
                                }
                            }
                        }
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void Login() {
            js_inject = Script.getScript(textBox1.Text, textBox2.Text);
            if (page_loaded) {
                Application.DoEvents();
                Inject();
            }
        }

        private void B_login_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e) {
            page_loaded = true;
            if (Wizard_Position == 1 && !has_injected) {
                //User is waiting for us.
                Login();
            }
            else if (first_step_passed) {
                try {
                    Inject();
                }
                catch { MessageBox.Show("Unexpected Error Occurred :-/"); /*Meh. Better safe than sorry.*/ }
            }
        }

        private void btnNext_Click(object sender, EventArgs e) {
            Next();
        }

        private void lbAbout_Click(object sender, EventArgs e) {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            MessageBox.Show("Truffle needs your personal information to connect with Blackboard and access your units.\r\n\r\nWe promise not steal your info - Truffle encrypts it and keeps it exclusively on YOUR computer.");
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK) {
                txLocation.Text = dlg.SelectedPath;
            }
        }
    }
}
