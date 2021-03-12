using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftACBrowser
{
    public partial class BrowserControlPage : UserControl
    {
        MacroData macroData;
        HMExtension hm = null;
        CLExtension cl = null;
        BLExtension bl = null;

        public BrowserControlPage()
        {
            InitializeComponent();

            this.web.ScriptErrorsSuppressed = true;
            
            hm = new HMExtension(web);
            bl = new BLExtension(web);
            cl = new CLExtension(web);


            hmCodeControl1.initialize(web);
        }

        private void btnHM_Click(object sender, EventArgs e)
        {
            if(hm == null)
                hm = new HMExtension(web);

            hmCodeControl1.SetCodeExtension(GiftCodeType.HappyMoneyCash);
            hmCodeControl1.GoToLogin();
        }


        private void btnBL_Click(object sender, EventArgs e)
        {
            if(bl== null)
                bl = new BLExtension(web);

            hmCodeControl1.SetCodeExtension(GiftCodeType.BookNLife);
            hmCodeControl1.GoToLogin();

        }


        private void btnCL_Click(object sender, EventArgs e)
        {
            if(cl == null)
                cl = new CLExtension(web);
            hmCodeControl1.SetCodeExtension(GiftCodeType.Cultureland);
            hmCodeControl1.GoToLogin();
        }


        private void web_NewWindow(object sender, CancelEventArgs e)
        {
            Console.WriteLine("NewWindows " + web.StatusText);
            e.Cancel = true;
        }


    }
}
