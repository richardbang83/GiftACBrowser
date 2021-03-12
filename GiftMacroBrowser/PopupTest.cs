using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftACBrowser
{
    public partial class PopupTest : Form
    {
        public PopupTest()
        {
            InitializeComponent();
        }

        WebBrowserEvents webEvent;
        private void button1_Click(object sender, EventArgs e)
        {
            webEvent = new WebBrowserEvents(webBrowser1);
            webBrowser1.Navigate("https://www.happymoney.co.kr/svc/");
        }
    }
}
