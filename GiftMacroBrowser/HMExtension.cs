using GNet.IO;
using MSHTML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftMacroBrowser
{
    public class HMCode
    {
        public List<string> pinNums = new List<string>();
        public string issuedate;
    }

    internal class HMExtension
    {
        private WebBrowser web;
        private HtmlDocument doc;
        private CountdownEvent cdeNav;

        public HMExtension(WebBrowser web)
        {
            this.web = web;
            this.doc = web.Document;
            this.web.Navigated += Web_Navigated;
        }

        private void Web_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if(cdeNav != null && cdeNav.CurrentCount > 0)
            {
                cdeNav.Signal();
            }
        }

        private void AddTen()
        {
            var el = doc.GetElementById("addTen");
            el.InvokeMember("click");
        }

        /// <summary>
        /// 입력받은 문자열이 cash code의 패턴인지를 확인함.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private List<HMCode> parseCode(string strCode)
        {
            Regex regex = new Regex(@"([0-9]{4})-([0-9]{4})-([0-9]{4})-([0-9]{4})_([0-9]{8})");
            var trimStr = strCode.Replace(" ", "");
            MatchCollection matchCodes = regex.Matches(trimStr);

            List<HMCode> codeList = new List<HMCode>();

            if (matchCodes.Count > 0)
            {
                foreach (Match code in matchCodes)
                {
                    HMCode hc = new HMCode();
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

        private Task Navigate(Uri url)
        {
            cdeNav = new CountdownEvent(1);
            web.Navigate(url);

            return Task.Run(() => {
                cdeNav.Wait();
                });
        }

        public HtmlElement GetElementsClose()
        {
            var buttons = doc.GetElementsByTagName("input");

            foreach (HtmlElement button in buttons)
            {
                if (button.GetAttribute("className") == "ir btnClose js-btnclose")
                {
                    if (button.Parent.GetAttribute("className") == "howTouseLy")
                    {
                        return button;
                    }
                }
            }
            return null;
        }

        internal static async void ExcuteMacro(WebBrowser web, string textData)
        {
            HMExtension hm = new HMExtension(web);
            var doc = hm.doc;

            var codeList = hm.parseCode(textData);

            if (codeList == null)
                return;

            while (codeList.Count > 0)
            {
                await hm.Navigate(new Uri("https://www.happymoney.co.kr/svc/cash/giftCardCharge.hm"));
                await Task.Delay(1000);

                HtmlUtils.DisableAlertPopup(web);

                // 결제비밀번호 사용안내 layer popup 종료
                var closeButton = hm.GetElementsClose();
                HtmlElement chargeButton = HtmlUtils.GetElementsByClass(doc, "input", "btn60 btn_4 btnCharge");

                // 결제 비밀번호 창 닫기
                hm.ClickButton(closeButton);
                await Task.Delay(300);                

                if (codeList.Count > 5)
                {
                    hm.AddTen();
                    await Task.Delay(500);
                }

                var cpltCode = new List<HMCode>();
                await Task.Run(() =>
                    codeList.Take(10).ToList().ForEach(h =>
                    {
                        var idx = codeList.IndexOf(h);
                        hm.DoInputCode(idx + 1, h).Wait();
                        cpltCode.Add(h);
                    })
                );

                cpltCode.ForEach(ch => codeList.Remove(ch));

                hm.ClickButton(chargeButton);

                await Task.Delay(2000);
                if (codeList.Count == 0)
                {
                    MessageBox.Show("GiftCharging is completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void ClickButton(HtmlElement button)
        {
            if (button == null)
            {
                Console.WriteLine("Failed to find Charge Button");
                return;
            }

            button.InvokeMember("click");
        }


        private async Task DoInputCode(int idx, HMCode code)
        {
            var pwdEl = doc.GetElementById($"pinNo1_{idx}");
            pwdEl.Focus();

            for (int j = 0; j < code.pinNums.Count; j++)
            {
                pwdEl = doc.GetElementById($"pinNo{j + 1}_{idx}");
                pwdEl.Focus();

                InputSimulator.Write(code.pinNums[j]);
                await Task.Delay(300);
            }

            pwdEl = doc.GetElementById($"issuedDate_{idx}");
            pwdEl.Focus();

            InputSimulator.Write(code.issuedate);
            await Task.Delay(300);
        }
    }
}
