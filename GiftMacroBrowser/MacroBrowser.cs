using ACBrowser;
using GNet.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftMacroBrowser
{
    public partial class MacroBrowser : Form
    {
        MacroData macroData;

        public MacroBrowser()
        {
            InitializeComponent();
            this.web.Url = new Uri("http://www.happymoney.co.kr");
            this.web.ScriptErrorsSuppressed = true;
            
        }

        private void web_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void menuInputCode_Click(object sender, EventArgs e)
        {
            InputTextBrowser popup = new InputTextBrowser();
            var res = popup.ShowDialog(this);
            if (res != DialogResult.OK)
            {
                Console.WriteLine("cancel");
                return;
            }

            macroData = popup.InputData;   
        }


        private void menuExcute_Click(object sender, EventArgs e)
        {
            switch(macroData.CodeType)
            {
                case GiftCodeType.HappyMoneyCash:
                    HtmlUtils.DisableAlertPopup(web);
                    HMExtension.ExcuteMacro(web, macroData.TextData);
                    break;
            }

        }

        const int WM_KEYDOWN = 0x0100, WM_KEYUP = 0x0101, WM_CHAR = 0x0102, WM_SYSKEYDOWN = 0x0104, WM_SYSKEYUP = 0x0105;
        Keys lastKeyPressed = Keys.None;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                lastKeyPressed = keyData;
                switch (keyData)
                {
                    case Keys.F1:
                        this.transparentPanel1.Enabled = true;
                        this.transparentPanel1.BringToFront();
                        break;
                    case Keys.F2:
                        this.transparentPanel1.Enabled = false;
                        this.web.BringToFront();
                        break;
                }
                Refresh();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
