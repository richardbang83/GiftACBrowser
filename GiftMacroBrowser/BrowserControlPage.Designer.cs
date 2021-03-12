namespace GiftACBrowser
{
    partial class BrowserControlPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserControlPage));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.web = new System.Windows.Forms.WebBrowser();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHM = new GiftACBrowser.MyButton();
            this.btnBL = new GiftACBrowser.MyButton();
            this.btnCL = new GiftACBrowser.MyButton();
            this.hmCodeControl1 = new GiftACBrowser.HMCodeControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1062, 640);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.web);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.hmCodeControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1056, 584);
            this.splitContainer1.SplitterDistance = 763;
            this.splitContainer1.TabIndex = 0;
            // 
            // web
            // 
            this.web.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web.Location = new System.Drawing.Point(0, 0);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(763, 584);
            this.web.TabIndex = 0;
            this.web.NewWindow += new System.ComponentModel.CancelEventHandler(this.web_NewWindow);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1062, 50);
            this.panel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnHM);
            this.flowLayoutPanel1.Controls.Add(this.btnBL);
            this.flowLayoutPanel1.Controls.Add(this.btnCL);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1062, 50);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnHM
            // 
            this.btnHM.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHM.BackgroundImage")));
            this.btnHM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHM.ForeColor = System.Drawing.Color.Transparent;
            this.btnHM.Location = new System.Drawing.Point(10, 3);
            this.btnHM.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnHM.Name = "btnHM";
            this.btnHM.Size = new System.Drawing.Size(144, 45);
            this.btnHM.TabIndex = 0;
            this.btnHM.UseVisualStyleBackColor = true;
            this.btnHM.Click += new System.EventHandler(this.btnHM_Click);
            // 
            // btnBL
            // 
            this.btnBL.BackColor = System.Drawing.Color.White;
            this.btnBL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBL.BackgroundImage")));
            this.btnBL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBL.ForeColor = System.Drawing.Color.Transparent;
            this.btnBL.Location = new System.Drawing.Point(174, 3);
            this.btnBL.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnBL.Name = "btnBL";
            this.btnBL.Size = new System.Drawing.Size(146, 45);
            this.btnBL.TabIndex = 1;
            this.btnBL.UseVisualStyleBackColor = false;
            this.btnBL.Click += new System.EventHandler(this.btnBL_Click);
            // 
            // btnCL
            // 
            this.btnCL.BackColor = System.Drawing.Color.White;
            this.btnCL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCL.BackgroundImage")));
            this.btnCL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCL.ForeColor = System.Drawing.Color.Transparent;
            this.btnCL.Location = new System.Drawing.Point(340, 3);
            this.btnCL.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnCL.Name = "btnCL";
            this.btnCL.Size = new System.Drawing.Size(152, 45);
            this.btnCL.TabIndex = 2;
            this.btnCL.UseVisualStyleBackColor = false;
            this.btnCL.Click += new System.EventHandler(this.btnCL_Click);
            // 
            // hmCodeControl1
            // 
            this.hmCodeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hmCodeControl1.Location = new System.Drawing.Point(0, 0);
            this.hmCodeControl1.Name = "hmCodeControl1";
            this.hmCodeControl1.Size = new System.Drawing.Size(289, 584);
            this.hmCodeControl1.TabIndex = 0;
            // 
            // BrowserControlPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BrowserControlPage";
            this.Size = new System.Drawing.Size(1062, 640);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.WebBrowser web;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MyButton btnHM;
        private MyButton btnBL;
        private MyButton btnCL;
        private HMCodeControl hmCodeControl1;
    }
}
