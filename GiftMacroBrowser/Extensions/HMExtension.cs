using GNet.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftACBrowser
{
    public class HMExtension : CodeExtension
    {

        enum HMCodeType
        {
            Cash,
            Giftcon,
        }

        public class HMCode
        {
            public List<string> pinNums = new List<string>();
            public string issuedate;

            public override string ToString()
            {
                var result = String.Join("-", pinNums.ToArray(), issuedate);
                return result;                
            }
        }

        

        private WebBrowser web;
        private HtmlDocument doc;
        private CountdownEvent cdeNav;

        public HMExtension(WebBrowser web)
        {
            this.web = web;
            this.doc = web.Document;
            this.web.Navigated += Web_Navigated;
        }

        public Task GoToLogin() => Navigate("https://www.happymoney.co.kr/svc/login/login.hm");

        private Task GoToGiftCharge() => Navigate("https://www.happymoney.co.kr/svc/cash/giftCardCharge.hm");

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
        private List<HMCode> parseCashCode(string strCode)
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

        private Task Navigate(string url)
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


        public async void ExcuteGiftMacro(string codeText, string phonenum)
        {
            doc = web.Document;

            // 브라우저에서 매치 코드 찾기 
            var codeList = parseGiftCode(codeText);

            // 충전 페이지로 이동
            await Navigate("https://www.happymoney.co.kr/svc/card/exchangeCoupon.hm");
            await Task.Delay(1000);

            await Task.Run(() =>
            {
                foreach (var cd in codeList)
                {
                    // 원하는 쿠폰 선택 ex) giftcoupon
                    SelectCouponToChange();
                    Thread.Sleep(500);

                    HtmlUtils.DisableAlertPopup(doc);

                    // 동의하기 버튼 클릭
                    HtmlElement agreeBtn = doc.GetElementById("agreeThisOne");
                    ClickButton(agreeBtn);
                    Thread.Sleep(500);

                    // 코드 입력
                    DoGiftCoupontCode(phonenum, cd).Wait();
                    Thread.Sleep(500);

                    // 확인 버튼 입력
                    HtmlElement confirmBtn = doc.GetElementById("couponRetrieve");
                    ClickButton(confirmBtn);
                    Thread.Sleep(500);

                    // 해피캐시로 충전하기 버튼 입력
                    ToHappyCash();
                    Thread.Sleep(500);
                }
            }
            );
        }


        bool giftSelected = false;
        internal void SelectCouponType(string codenum)
        {
            giftSelected = true;
        }

        public HtmlElement SelectCouponToChange()
        {
            var buttons = doc.GetElementsByTagName("ul");
            
            foreach (HtmlElement button in buttons)
            {
                if (button.GetAttribute("className") == "inDetailBox")
                {
                    var cpBtn = button.Children[1].Children[0];
                    ClickButton(cpBtn);
                }
            }
            return null;
        }


        public void ToHappyCash()
        {
            var button = HtmlUtils.GetElementsByClass(doc, "div", "hpCash");

            try
            {
                Console.WriteLine(button);
                // 충전이 실패하면 패스 
                if (button != null)
                    ClickButton(button.Children[0]);
            }
            catch(Exception)
            {
                Console.WriteLine("충전실패");
            }
        }



        /// <summary>
        /// gift code 패턴문자열을 확인함
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private List<string> parseGiftCode(string strCode)
        {
            Regex regex = new Regex(@"[0-9]{12}");
            var trimStr = strCode.Replace(" ", "");
            MatchCollection matchCodes = regex.Matches(trimStr);

            List<string> codeList = new List<string>();

            if (matchCodes.Count > 0)
            {
                foreach (Match code in matchCodes)
                {
                    codeList.Add(code.Value);
                }
                return codeList;
            }
            return null;
        }

        /// <summary>
        /// Happy money 상품권 등록 매크로
        /// </summary>
        /// <param name="textData"></param>
        internal async void ExcuteMacro(string textData)
        {
            doc = web.Document;
            var codeList = parseCashCode(textData);

            if (codeList == null)
                return;

            while (codeList.Count > 0)
            {
                await GoToGiftCharge();
                //await Navigate(new Uri("https://www.happymoney.co.kr/svc/cash/giftCardCharge.hm"));
                await Task.Delay(1000);

                HtmlUtils.DisableAlertPopup(web);

                // 결제비밀번호 사용안내 layer popup 종료
                var closeButton = GetElementsClose();
                HtmlElement chargeButton = HtmlUtils.GetElementsByClass(doc, "input", "btn60 btn_4 btnCharge");

                // 결제 비밀번호 창 닫기
                ClickButton(closeButton);
                await Task.Delay(300);                

                if (codeList.Count > 5)
                {
                    AddTen();
                    await Task.Delay(500);
                }

                var cpltCode = new List<HMCode>();
                await Task.Run(() =>
                    codeList.Take(10).ToList().ForEach(h =>
                    {
                        var idx = codeList.IndexOf(h);
                        DoInputCode(idx + 1, h).Wait();
                        cpltCode.Add(h);
                    })
                );

                cpltCode.ForEach(ch => codeList.Remove(ch));

                ClickButton(chargeButton);

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

        private async Task DoGiftCoupontCode(string phoneNo, string couponNo)
        {
            var pwdEl = doc.GetElementById($"phoneNo");
            pwdEl.Focus();
            await Task.Delay(100);
            pwdEl.InnerText = phoneNo;

            pwdEl = doc.GetElementById($"couponNo");
            pwdEl.Focus();
            await Task.Delay(100);
            pwdEl.InnerText = couponNo;
        }



        private async Task DoInputCode(int idx, HMCode code)
        {
            var pwdEl = doc.GetElementById($"pinNo1_{idx}");
            pwdEl.Focus();
            await Task.Delay(100);
            pwdEl.InnerText = code.pinNums[0];

            pwdEl = doc.GetElementById($"pinNo2_{idx}");
            pwdEl.Focus();
            await Task.Delay(100);
            InputSimulator.Write(code.pinNums[1]);
            await Task.Delay(300);

            pwdEl = doc.GetElementById($"pinNo3_{idx}");
            pwdEl.Focus();
            await Task.Delay(100);
            pwdEl.InnerText = code.pinNums[2];

            pwdEl = doc.GetElementById($"pinNo4_{idx}");
            pwdEl.Focus();
            await Task.Delay(100);
            InputSimulator.Write(code.pinNums[3]);
            await Task.Delay(300);


            pwdEl = doc.GetElementById($"issuedDate_{idx}");
            pwdEl.Focus();
            await Task.Delay(100);
            pwdEl.InnerText = code.issuedate;
            await Task.Delay(300);
        }

        List<HMCode> codeList = new List<HMCode>();

        
        public void GotoLogin()
        {
            Task.Run(() => web.Navigate("https://www.happymoney.co.kr/svc/login/login.hm"));
        }



        public string[] GetCodeStringList(string codeText)
        {
            var codelist = parseCashCode(codeText);

            return null;
        }

        public void Clear()
        {
            codeList.Clear();
        }



        public void ExecuteCharge(params string[] args)
        {
            if(args.Length == 1)
            {
                ExcuteMacro(args[0]);
            }
            else
            {
                var gifttype = args[0];

                switch(gifttype)
                {
                    case "giftcon":
                        // code
                        ExcuteGiftMacro(args[1], args[2]);
                        break;
                }
            }
            
        }
    }
}
