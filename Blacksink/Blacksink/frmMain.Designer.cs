namespace Blacksink
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnDock = new System.Windows.Forms.Panel();
            this.pnMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnDock
            // 
            this.pnDock.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnDock.Location = new System.Drawing.Point(0, 0);
            this.pnDock.Name = "pnDock";
            this.pnDock.Size = new System.Drawing.Size(1110, 28);
            this.pnDock.TabIndex = 0;
            this.pnDock.Visible = false;
            // 
            // pnMain
            // 
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 28);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1110, 712);
            this.pnMain.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 740);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnDock);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truffle";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnDock;
        private System.Windows.Forms.Panel pnMain;
    }
}