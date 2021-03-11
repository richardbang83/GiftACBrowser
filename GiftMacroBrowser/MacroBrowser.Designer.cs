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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacroBrowser));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.메뉴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그인ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.환경설정ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.입력ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPopupCodeBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExcute = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolNavHM = new System.Windows.Forms.ToolStripButton();
            this.toolNavBL = new System.Windows.Forms.ToolStripButton();
            this.toolNavCL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.transparentPanel1 = new ACBrowser.TransparentPanel(this.components);
            this.web = new System.Windows.Forms.WebBrowser();

            this.hmgiftCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 981);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 30);
            this.splitContainer1.SplitterDistance = 324;
            this.splitContainer1.TabIndex = 6;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴ToolStripMenuItem,
            this.입력ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(324, 30);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // 메뉴ToolStripMenuItem
            // 
            this.메뉴ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.로그인ToolStripMenuItem1,
            this.환경설정ToolStripMenuItem1});
            this.메뉴ToolStripMenuItem.Enabled = false;
            this.메뉴ToolStripMenuItem.Name = "메뉴ToolStripMenuItem";
            this.메뉴ToolStripMenuItem.Size = new System.Drawing.Size(43, 26);
            this.메뉴ToolStripMenuItem.Text = "메뉴";
            // 
            // 로그인ToolStripMenuItem1
            // 
            this.로그인ToolStripMenuItem1.Name = "로그인ToolStripMenuItem1";
            this.로그인ToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.로그인ToolStripMenuItem1.Text = "로그인";
            // 
            // 환경설정ToolStripMenuItem1
            // 
            this.환경설정ToolStripMenuItem1.Name = "환경설정ToolStripMenuItem1";
            this.환경설정ToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.환경설정ToolStripMenuItem1.Text = "환경설정";
            // 
            // 입력ToolStripMenuItem
            // 
            this.입력ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPopupCodeBrowser,

            this.menuExcute,
            this.hmgiftCode});

            this.입력ToolStripMenuItem.Name = "입력ToolStripMenuItem";
            this.입력ToolStripMenuItem.Size = new System.Drawing.Size(43, 26);
            this.입력ToolStripMenuItem.Text = "입력";
            // 
            // menuPopupCodeBrowser
            // 
            this.menuPopupCodeBrowser.Name = "menuPopupCodeBrowser";

            this.menuPopupCodeBrowser.Size = new System.Drawing.Size(180, 22);

            this.menuPopupCodeBrowser.Text = "상품권코드입력";
            this.menuPopupCodeBrowser.Click += new System.EventHandler(this.menuInputCode_Click);
            // 
            // menuExcute
            // 
            this.menuExcute.Name = "menuExcute";

            this.menuExcute.Size = new System.Drawing.Size(180, 22);

            this.menuExcute.Text = "실행하기";
            this.menuExcute.Click += new System.EventHandler(this.menuExcute_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNavHM,
            this.toolNavBL,
            this.toolNavCL,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(936, 30);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolNavHM
            // 
            this.toolNavHM.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolNavHM.BackgroundImage")));
            this.toolNavHM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNavHM.Image = ((System.Drawing.Image)(resources.GetObject("toolNavHM.Image")));
            this.toolNavHM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNavHM.Name = "toolNavHM";
            this.toolNavHM.Size = new System.Drawing.Size(23, 27);
            this.toolNavHM.Text = "Go to HappyMoney";
            this.toolNavHM.ToolTipText = "Go to HappyMoney";
            this.toolNavHM.Click += new System.EventHandler(this.toolNavHM_Click);
            // 
            // toolNavBL
            // 
            this.toolNavBL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNavBL.Image = ((System.Drawing.Image)(resources.GetObject("toolNavBL.Image")));
            this.toolNavBL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNavBL.Name = "toolNavBL";
            this.toolNavBL.Size = new System.Drawing.Size(23, 27);
            this.toolNavBL.Text = "Go to BookNLife";
            this.toolNavBL.Click += new System.EventHandler(this.toolNavBL_Click);
            // 
            // toolNavCL
            // 
            this.toolNavCL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNavCL.Image = ((System.Drawing.Image)(resources.GetObject("toolNavCL.Image")));
            this.toolNavCL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNavCL.Name = "toolNavCL";
            this.toolNavCL.Size = new System.Drawing.Size(23, 27);
            this.toolNavCL.Text = "Go to Cultureland";
            this.toolNavCL.Click += new System.EventHandler(this.toolNavCL_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.transparentPanel1);
            this.panel1.Controls.Add(this.web);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 951);
            this.panel1.TabIndex = 7;
            // 
            // transparentPanel1
            // 
            this.transparentPanel1.BackColor = System.Drawing.Color.Transparent;
            this.transparentPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transparentPanel1.Enabled = false;
            this.transparentPanel1.Location = new System.Drawing.Point(0, 0);
            this.transparentPanel1.Name = "transparentPanel1";
            this.transparentPanel1.Opacity = 40;
            this.transparentPanel1.Size = new System.Drawing.Size(1264, 951);
            this.transparentPanel1.TabIndex = 1;
            // 
            // web
            // 
            this.web.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web.Location = new System.Drawing.Point(0, 0);
            this.web.Margin = new System.Windows.Forms.Padding(0);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(1264, 951);
            this.web.TabIndex = 0;
            this.web.NewWindow += new System.ComponentModel.CancelEventHandler(this.web_NewWindow);
            // 

            // hmgiftCode
            // 
            this.hmgiftCode.Name = "hmgiftCode";
            this.hmgiftCode.Size = new System.Drawing.Size(180, 22);
            this.hmgiftCode.Text = "기프티콘";
            this.hmgiftCode.Click += new System.EventHandler(this.hmgiftCode_Click);
            // 

            // MacroBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 981);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MacroBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatic Charging Browser v0.1";
            this.Load += new System.EventHandler(this.MacroBrowser_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 메뉴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 환경설정ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 입력ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuPopupCodeBrowser;
        private System.Windows.Forms.ToolStripMenuItem menuExcute;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolNavBL;
        private System.Windows.Forms.ToolStripButton toolNavHM;
        private System.Windows.Forms.ToolStripButton toolNavCL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser web;
        private ACBrowser.TransparentPanel transparentPanel1;

        private System.Windows.Forms.ToolStripMenuItem hmgiftCode;

    }
}