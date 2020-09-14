using GNet.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void menuImportTxtFile_Click(object sender, EventArgs e)
        {
            // 문자열에서 상품권의 종류를 파싱하는것이 필요함.

        }

        private void menuExcute_Click(object sender, EventArgs e)
        {
            switch(macroData.CodeType)
            {
                case GiftCodeType.HappyMoneyCash:
                    HtmlUtils.DisableAlertPopup(web);
                    HMExtension.ExcuteMacro(web.Document, macroData.TextData);
                    break;
            }

        }
    }
}
