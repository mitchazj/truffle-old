namespace Blacksink
{
    partial class frmUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdate));
            this.pnDecorative = new System.Windows.Forms.Panel();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.btnSkip = new System.Windows.Forms.Button();
            this.lbAbout = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRemind = new System.Windows.Forms.Button();
            this.lbHeader = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnBottom.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.pnDecorative.TabIndex = 6;
            // 
            // pnBottom
            // 
            this.pnBottom.BackColor = System.Drawing.SystemColors.Control;
            this.pnBottom.Controls.Add(this.btnRemind);
            this.pnBottom.Controls.Add(this.btnSkip);
            this.pnBottom.Controls.Add(this.lbAbout);
            this.pnBottom.Controls.Add(this.btnInstall);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 257);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(643, 40);
            this.pnBottom.TabIndex = 5;
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkip.Location = new System.Drawing.Point(328, 9);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 1;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            // 
            // lbAbout
            // 
            this.lbAbout.AutoSize = true;
            this.lbAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAbout.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbAbout.Location = new System.Drawing.Point(12, 14);
            this.lbAbout.Name = "lbAbout";
            this.lbAbout.Size = new System.Drawing.Size(77, 13);
            this.lbAbout.TabIndex = 2;
            this.lbAbout.Text = "About Truffle...";
            // 
            // btnInstall
            // 
            this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstall.Location = new System.Drawing.Point(516, 9);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(117, 23);
            this.btnInstall.TabIndex = 0;
            this.btnInstall.Text = "Install Now";
            this.btnInstall.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbMessage);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lbHeader);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 256);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox3.Image = global::Blacksink.Properties.Resources.tall;
            this.pictureBox3.Location = new System.Drawing.Point(30, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(167, 226);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(188)))));
            this.label9.Location = new System.Drawing.Point(217, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Stable Update Available!";
            // 
            // btnRemind
            // 
            this.btnRemind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemind.Location = new System.Drawing.Point(409, 9);
            this.btnRemind.Name = "btnRemind";
            this.btnRemind.Size = new System.Drawing.Size(101, 23);
            this.btnRemind.TabIndex = 3;
            this.btnRemind.Text = "Remind me later";
            this.btnRemind.UseVisualStyleBackColor = true;
            // 
            // lbHeader
            // 
            this.lbHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbHeader.Location = new System.Drawing.Point(217, 169);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(186, 20);
            this.lbHeader.TabIndex = 22;
            this.lbHeader.Text = "New in this version (v0.4):";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.Location = new System.Drawing.Point(218, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(387, 33);
            this.label10.TabIndex = 23;
            this.label10.Text = "To avoid potential problems, we strongly recommend that you stay up-to-date with " +
    "the latest Truffle release :-) ";
            // 
            // lbMessage
            // 
            this.lbMessage.Location = new System.Drawing.Point(218, 194);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(388, 47);
            this.lbMessage.TabIndex = 24;
            this.lbMessage.Text = "Critical bug fixes [High priority] + performance improvements";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(218, 141);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(136, 13);
            this.linkLabel1.TabIndex = 25;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Want to shout us a coffee?";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(218, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 33);
            this.label1.TabIndex = 26;
            this.label1.Text = "Remember that Truffle is unofficial software (at least for now), maintained for f" +
    "ree by students just like yourself <3";
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(643, 297);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnDecorative);
            this.Controls.Add(this.pnBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truffle | Update Available";
            this.TopMost = true;
            this.pnBottom.ResumeLayout(false);
            this.pnBottom.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnDecorative;
        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Label lbAbout;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRemind;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
    }
}