namespace Blacksink
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.pnDecorative = new System.Windows.Forms.Panel();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnContain = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAbout = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnBottom.SuspendLayout();
            this.pnContain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnDecorative
            // 
            this.pnDecorative.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.pnDecorative.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnDecorative.Location = new System.Drawing.Point(0, 220);
            this.pnDecorative.Name = "pnDecorative";
            this.pnDecorative.Size = new System.Drawing.Size(484, 1);
            this.pnDecorative.TabIndex = 6;
            // 
            // pnBottom
            // 
            this.pnBottom.BackColor = System.Drawing.SystemColors.Control;
            this.pnBottom.Controls.Add(this.label3);
            this.pnBottom.Controls.Add(this.btnClose);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 221);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(484, 40);
            this.pnBottom.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(399, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnContain
            // 
            this.pnContain.Controls.Add(this.label2);
            this.pnContain.Controls.Add(this.label1);
            this.pnContain.Controls.Add(this.lbAbout);
            this.pnContain.Controls.Add(this.label9);
            this.pnContain.Controls.Add(this.label10);
            this.pnContain.Controls.Add(this.pictureBox3);
            this.pnContain.Controls.Add(this.pictureBox1);
            this.pnContain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContain.Location = new System.Drawing.Point(0, 0);
            this.pnContain.Name = "pnContain";
            this.pnContain.Size = new System.Drawing.Size(484, 220);
            this.pnContain.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(240, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "github.com/mitchazj/truffle";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Contribute to Truffle development!";
            // 
            // lbAbout
            // 
            this.lbAbout.AutoSize = true;
            this.lbAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAbout.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbAbout.Location = new System.Drawing.Point(195, 121);
            this.lbAbout.Name = "lbAbout";
            this.lbAbout.Size = new System.Drawing.Size(145, 13);
            this.lbAbout.TabIndex = 24;
            this.lbAbout.Text = "https://mitchellazj.com/truffle";
            this.lbAbout.Click += new System.EventHandler(this.lbAbout_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(188)))));
            this.label9.Location = new System.Drawing.Point(194, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(246, 46);
            this.label9.TabIndex = 26;
            this.label9.Text = "Truffle\r\n© Mitchell Johnson 2016.";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.Location = new System.Drawing.Point(195, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(278, 41);
            this.label10.TabIndex = 27;
            this.label10.Text = "Truffle aims to simplify the way uni students manage their course materials by au" +
    "tomatically synchronizing Blackboard content.";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox3.Image = global::Blacksink.Properties.Resources.logo;
            this.pictureBox3.Location = new System.Drawing.Point(16, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(167, 209);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Blacksink.Properties.Resources.GitHub_Mark;
            this.pictureBox1.Location = new System.Drawing.Point(191, 140);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "version 0.4";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.pnContain);
            this.Controls.Add(this.pnDecorative);
            this.Controls.Add(this.pnBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Truffle";
            this.pnBottom.ResumeLayout(false);
            this.pnBottom.PerformLayout();
            this.pnContain.ResumeLayout(false);
            this.pnContain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnDecorative;
        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnContain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbAbout;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}
