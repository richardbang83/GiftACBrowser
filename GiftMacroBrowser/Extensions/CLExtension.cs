using GiftACBrowser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftACBrowser
{

    public class CLExtension
    {
        public class CLCode
        {
            public List<string> pinNums = new List<string>();
            public string issuedate;
        }


        private WebBrowser web;
        private HtmlDocument doc;

        public CLExtension(WebBrowser web)
        {
            this.web = web;
            this.doc = web.Document;
        }

        private void AddTen()
        {
            var el = ("btnPlus");
            
        }

        public void GoToLogin()
        {
            web.Navigate("https://www.cultureland.co.kr/signin/login.do");
        }

        internal async void  ExcuteMacro(string textData)
        {
            
        }
    }
}
