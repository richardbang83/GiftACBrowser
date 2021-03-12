using GiftACBrowser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftACBrowser
{

    public class CLExtension : CodeExtension
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
        
        internal async void  ExcuteMacro(string textData)
        {
            
        }

        public dynamic ParseCode(string codeText)
        {

            return null;
        }

        public void GotoLogin()
        {
            Task.Run(() => web.Navigate("https://www.cultureland.co.kr/signin/login.do"));
        }

        public string[] GetCodeStringList(string codeText)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            
        }

        public void ExecuteCharge(params string[] codeText)
        {
           
        }
    }
}
