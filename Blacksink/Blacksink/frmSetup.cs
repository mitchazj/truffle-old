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
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace Blacksink
{
    /// <summary>
    /// This form handles the inital connection to Blackboard.
    /// It currently contains the most fool-proof (albeit in bad need of refactoring) login code.
    /// TODO: refactor this into a few different classes (priority urgent)
    /// </summary>
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

        public Timer connectionTimeout = new Timer() { Interval = 100 };
        public DateTime connection_started = DateTime.Now;
        bool allowedToContinue = true;

        public frmSetup() {
            InitializeComponent();
            //b_login = new ChromiumWebBrowser(URL);
            b_login = new ChromiumWebBrowser("local");
            b_login.FrameLoadEnd += B_login_FrameLoadEnd;
            OnAct = Act;
            connectionTimeout.Tick += ConnectionTimeout_Tick;

            //Form test = new Form();
            //test.Controls.Add(b_login);
            //test.Show();
        }

        private void ConnectionTimeout_Tick(object sender, EventArgs e) {
            if (DateTime.Now - connection_started > TimeSpan.FromSeconds(20)) {
                allowedToContinue = false;
                Console.WriteLine("Timer tick");
                b_login.Stop();
                connectionTimeout.Stop();
                this.Invoke(OnAct, false);
                MessageBox.Show("Timeout Error: Unable to connect to Blackboard. Please double-check your password and your internet connection", "Truffle");
                Application.DoEvents();
            }
        }

        private void StartTimeout() {
            connection_started = DateTime.Now;
            allowedToContinue = true;
            if (!connectionTimeout.Enabled) {
                connectionTimeout.Start();
                Console.WriteLine("Timer started");
            }
        }

        private void Next() {
            if (Wizard_Position == 0) {
                ++Wizard_Position;
                pnContain.Visible = false;
                pnConnecting.Visible = true;
                btnNext.Enabled = false;
                allowedToContinue = true;
                Login();
            }
            else if (Wizard_Position == 1) {
                ++Wizard_Position;
                connectionTimeout.Stop();
                pnConnecting.Visible = false;
                pnFileLocation.Visible = true;
                btnNext.Enabled = true;
                btnNext.Text = "Finish";
                try {
                    if (Properties.Settings.Default.StorageLocation != "") {
                        txLocation.Text = Properties.Settings.Default.StorageLocation;
                    } else {
                        txLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Truffle\\QUT\\Units\\";
                    }
                }
                catch { txLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Truffle\\QUT\\Units\\"; }
            }
            else if (Wizard_Position == 2) {
                try {
                    Directory.CreateDirectory(txLocation.Text);
                } catch {
                    MessageBox.Show("Invalid folder path, or permission to access was denied.");
                    return;
                }

                //Parse the location
                string location = txLocation.Text.Replace("/", "\\");
                location = location.EndsWith("\\") ? location : location + "\\";

                //It can be either where are files are already stored, or an empty directory.
                if (Properties.Settings.Default.StorageLocation == location ||
                    (Directory.GetFiles(location).Length == 0 && Directory.GetDirectories(location).Length == 0)) {

                    //We are done! Save our configuration to settings
                    Properties.Settings.Default.StorageLocation = location;
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
            allowedToContinue = false;
            failed_passes = 0;
            page_loaded = false;
            has_injected = false;
            first_step_passed = false;
            js_inject = "";
            b_login.Stop();
            b_login.Load(URL);
            pnContain.Visible = true;
            pnConnecting.Visible = false;
            pnFileLocation.Visible = false;
            connectionTimeout.Stop();
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
            if (allowedToContinue) {
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
                                    MessageBox.Show("Could not connect to Blackboard.", "Truffle");
                                    this.Invoke(OnAct, false);
                                }
                            }
                            else {
                                Application.DoEvents();
                                ++failed_passes;
                                if (failed_passes == 2) {
                                    if (result == "login successful" || result == "login unsuccessful") {
                                        //Uh-oh. We should be well past this stage. Abort, abort!
                                        Application.DoEvents();
                                        MessageBox.Show("Invalid Username/Password", "Truffle");
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
        }

        private void Login() {
            new Thread(() => {
                js_inject = Script.getScript(textBox1.Text, textBox2.Text);
                StartTimeout();
                Console.WriteLine("Login called");
                if (page_loaded) {
                    Inject();
                }
            }).Start();
        }

        private void B_login_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e) {
            page_loaded = true;
            Console.WriteLine("Hello from the other side!");
            if (Wizard_Position == 1 && !has_injected) {
                //User is waiting for us.
                Login();
            }
            else if (first_step_passed) {
                try {
                    Inject();
                }
                catch { MessageBox.Show("Unexpected Error Occurred :-/", "Truffle"); /*Meh. Better safe than sorry.*/ }
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
            MessageBox.Show("Truffle needs your personal information to connect with Blackboard and access your units.\r\n\r\nWe promise not steal your info - Truffle encrypts it and keeps it exclusively on YOUR computer.", "Truffle");
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK) {
                txLocation.Text = dlg.SelectedPath;
                txLocation.Text = txLocation.Text.EndsWith("\\") ? txLocation.Text : txLocation.Text + "\\";
            }
        }
    }
}
