namespace Blacksink
{
    partial class frmSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetup));
            this.pnDecorative = new System.Windows.Forms.Panel();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbAbout = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnContain = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbStudentNumber = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbHeader = new System.Windows.Forms.Label();
            this.lbSubheader = new System.Windows.Forms.Label();
            this.pnConnecting = new System.Windows.Forms.Panel();
            this.prgConnect = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnFileLocation = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txLocation = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnBottom.SuspendLayout();
            this.pnContain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnConnecting.SuspendLayout();
            this.pnFileLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pnDecorative
            // 
            this.pnDecorative.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.pnDecorative.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnDecorative.Location = new System.Drawing.Point(0, 256);
            this.pnDecorative.Name = "pnDecorative";
            this.pnDecorative.Size = new System.Drawing.Size(643, 1);
            this.pnDecorative.TabIndex = 4;
            // 
            // pnBottom
            // 
            this.pnBottom.BackColor = System.Drawing.SystemColors.Control;
            this.pnBottom.Controls.Add(this.btnCancel);
            this.pnBottom.Controls.Add(this.lbAbout);
            this.pnBottom.Controls.Add(this.btnNext);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 257);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(643, 40);
            this.pnBottom.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(477, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Back";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            // 
            // lbAbout
            // 
            this.lbAbout.AutoSize = true;
            this.lbAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAbout.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbAbout.Location = new System.Drawing.Point(12, 14);
            this.lbAbout.Name = "lbAbout";
            this.lbAbout.Size = new System.Drawing.Size(44, 13);
            this.lbAbout.TabIndex = 2;
            this.lbAbout.Text = "About...";
            this.lbAbout.Click += new System.EventHandler(this.lbAbout_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(558, 9);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pnContain
            // 
            this.pnContain.Controls.Add(this.linkLabel1);
            this.pnContain.Controls.Add(this.label1);
            this.pnContain.Controls.Add(this.textBox2);
            this.pnContain.Controls.Add(this.lbStudentNumber);
            this.pnContain.Controls.Add(this.textBox1);
            this.pnContain.Controls.Add(this.pictureBox1);
            this.pnContain.Controls.Add(this.lbHeader);
            this.pnContain.Controls.Add(this.lbSubheader);
            this.pnContain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContain.Location = new System.Drawing.Point(0, 0);
            this.pnContain.Name = "pnContain";
            this.pnContain.Size = new System.Drawing.Size(643, 256);
            this.pnContain.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(224, 191);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(337, 13);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Why is this necessary? What does Black-Sink do with my information?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "QUT Student Password:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(227, 168);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(380, 20);
            this.textBox2.TabIndex = 21;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // lbStudentNumber
            // 
            this.lbStudentNumber.AutoSize = true;
            this.lbStudentNumber.Location = new System.Drawing.Point(224, 113);
            this.lbStudentNumber.Name = "lbStudentNumber";
            this.lbStudentNumber.Size = new System.Drawing.Size(113, 13);
            this.lbStudentNumber.TabIndex = 20;
            this.lbStudentNumber.Text = "QUT Student Number:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(227, 129);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(380, 20);
            this.textBox1.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.Image = global::Blacksink.Properties.Resources.blacksink_text;
            this.pictureBox1.Location = new System.Drawing.Point(30, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 226);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // lbHeader
            // 
            this.lbHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(188)))));
            this.lbHeader.Location = new System.Drawing.Point(223, 68);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(350, 20);
            this.lbHeader.TabIndex = 12;
            this.lbHeader.Text = "Allow Black-Sink to access your student account";
            // 
            // lbSubheader
            // 
            this.lbSubheader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbSubheader.AutoSize = true;
            this.lbSubheader.Location = new System.Drawing.Point(224, 90);
            this.lbSubheader.Name = "lbSubheader";
            this.lbSubheader.Size = new System.Drawing.Size(354, 13);
            this.lbSubheader.TabIndex = 13;
            this.lbSubheader.Text = "Enter your student credentials below - we need them to access your units.";
            // 
            // pnConnecting
            // 
            this.pnConnecting.Controls.Add(this.prgConnect);
            this.pnConnecting.Controls.Add(this.label5);
            this.pnConnecting.Controls.Add(this.label6);
            this.pnConnecting.Location = new System.Drawing.Point(0, 0);
            this.pnConnecting.Name = "pnConnecting";
            this.pnConnecting.Size = new System.Drawing.Size(643, 256);
            this.pnConnecting.TabIndex = 5;
            this.pnConnecting.Visible = false;
            // 
            // prgConnect
            // 
            this.prgConnect.Location = new System.Drawing.Point(196, 138);
            this.prgConnect.MarqueeAnimationSpeed = 50;
            this.prgConnect.Name = "prgConnect";
            this.prgConnect.Size = new System.Drawing.Size(250, 23);
            this.prgConnect.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgConnect.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(188)))));
            this.label5.Location = new System.Drawing.Point(251, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Verifying Your Info";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Attempting to access QUT Blackboard...";
            // 
            // pnFileLocation
            // 
            this.pnFileLocation.Controls.Add(this.pictureBox2);
            this.pnFileLocation.Controls.Add(this.label3);
            this.pnFileLocation.Controls.Add(this.label4);
            this.pnFileLocation.Controls.Add(this.btnBrowse);
            this.pnFileLocation.Controls.Add(this.txLocation);
            this.pnFileLocation.Controls.Add(this.pictureBox3);
            this.pnFileLocation.Controls.Add(this.label9);
            this.pnFileLocation.Controls.Add(this.label10);
            this.pnFileLocation.Location = new System.Drawing.Point(0, 0);
            this.pnFileLocation.Name = "pnFileLocation";
            this.pnFileLocation.Size = new System.Drawing.Size(643, 256);
            this.pnFileLocation.TabIndex = 6;
            this.pnFileLocation.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Blacksink.Properties.Resources.tick;
            this.pictureBox2.Location = new System.Drawing.Point(221, 60);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(277, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Account Verified";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(301, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Black-Sink is now configured to use your Blackboard account.";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(532, 174);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 20;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txLocation
            // 
            this.txLocation.Location = new System.Drawing.Point(227, 176);
            this.txLocation.Name = "txLocation";
            this.txLocation.Size = new System.Drawing.Size(299, 20);
            this.txLocation.TabIndex = 19;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox3.Image = global::Blacksink.Properties.Resources.blacksink_text;
            this.pictureBox3.Location = new System.Drawing.Point(30, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(167, 226);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(188)))));
            this.label9.Location = new System.Drawing.Point(223, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(334, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "Where should we store your Blackboard stuff?";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(224, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(233, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Choose an empty folder, or leave this as default.";
            // 
            // frmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(643, 297);
            this.Controls.Add(this.pnFileLocation);
            this.Controls.Add(this.pnConnecting);
            this.Controls.Add(this.pnContain);
            this.Controls.Add(this.pnDecorative);
            this.Controls.Add(this.pnBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Black-Sink Setup";
            this.pnBottom.ResumeLayout(false);
            this.pnBottom.PerformLayout();
            this.pnContain.ResumeLayout(false);
            this.pnContain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnConnecting.ResumeLayout(false);
            this.pnConnecting.PerformLayout();
            this.pnFileLocation.ResumeLayout(false);
            this.pnFileLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnDecorative;
        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.Label lbAbout;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel pnContain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Label lbSubheader;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnConnecting;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnFileLocation;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar prgConnect;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txLocation;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbStudentNumber;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

