using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftACBrowser
{


    public class BLExtension
    {
        public class BLCode
        {
            public List<string> pinNums = new List<string>();
            public string issuedate;
        }


        private WebBrowser web;
        private System.Windows.Forms.HtmlDocument doc;

        // Pattern
        // url : https://www.booknlife.com/hp/payModule/CashChargeBnlVoucher.do
        // pin : inputS20 pinno1,pinno2,pinno3,pinno4, pincode

        public BLExtension(WebBrowser web)
        {
            this.web = web;
        }

        internal async void ExcuteMacro(string strCode)
        {
            this.doc = web.Document;


            WebBrowserControlXPathQueriesProcessor proc = new WebBrowserControlXPathQueriesProcessor(this.web);
            await Task.Delay(1000);

            var node2 = proc.GetHtmlElement("/html");

            var hhtmlWeb = new HtmlWeb();
            var htmlDoc =  hhtmlWeb.Load(web.Document.Url.AbsoluteUri);

            var node = htmlDoc.DocumentNode.SelectNodes("/html/body/form[1]/div[3]/div[2]/div/div[2]/div/div[1]/fieldset/p[3]/input");

            var chargeNode = web.Document.GetElementById("frmCashCharge");

            //htmlDoc.Load(doc.Url.AbsoluteUri);

            string xPath = "/html";
            string code = string.Format($"document.evaluate('{xPath}',document,null, XPathResult.FIRST_ORDERED_NODE_TYPE, null)");//.singleNodeValue;");
            var li = this.doc.InvokeScript("eval", new object[] { code }); //as HtmlElement;
            this.doc.InvokeScript("eval", new object[] { "alert('Hello world!');" });
        }


        private List<BLCode> parseCode(string strCode)
        {
            var trimStr = strCode.Replace(" ", "");

            Regex regex = new Regex(@"([0-9]{4})-([0-9]{4})-([0-9]{4})-([0-9]{4})-([0-9]{4})");
            MatchCollection matchCodes = regex.Matches(trimStr);

            List<BLCode> codeList = new List<BLCode>();

            if (matchCodes.Count > 0)
            {
                foreach (Match code in matchCodes)
                {
                    var hc = new BLCode();
                    for (int i = 0; i < 4; i++)
                    {
                        hc.pinNums.Add($"{code.Groups[i + 1]}");
                    }
                    hc.issuedate = $"{code.Groups[5]}";

                    codeList.Add(hc);
                }

                return codeList;
            }
            return null;
        }

        internal void GoToLogin()
        {
            web.Navigate("https://www.booknlife.com/hp/login.do");
        }


        private void GoToCashCharge()
        {
            web.Navigate("https://www.booknlife.com/hp/payModule/CashChargeBnlVoucher.do");
        }



    }
}
