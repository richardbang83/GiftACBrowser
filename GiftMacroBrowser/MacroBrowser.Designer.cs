namespace GiftACBrowser
{
    partial class MacroBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacroBrowser));
            this.browserControlPage1 = new GiftACBrowser.BrowserControlPage();
            this.SuspendLayout();
            // 
            // browserControlPage1
            // 
            this.browserControlPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserControlPage1.Location = new System.Drawing.Point(0, 0);
            this.browserControlPage1.Name = "browserControlPage1";
            this.browserControlPage1.Size = new System.Drawing.Size(1264, 981);
            this.browserControlPage1.TabIndex = 0;
            // 
            // MacroBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 981);
            this.Controls.Add(this.browserControlPage1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MacroBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatic Charging Browser v0.1";
            this.Load += new System.EventHandler(this.hmgiftCode_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private BrowserControlPage browserControlPage1;
    }
}