using GNet.IO;
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
        private HtmlDocument doc;
        public HMExtension(HtmlDocument doc)
        {
            this.doc = doc;
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

        internal static async void ExcuteMacro(HtmlDocument doc, string textData)
        {
            HMExtension hm = new HMExtension(doc);
            var codeList = hm.parseCode(textData);

            if (codeList == null)
                return;

            if (codeList.Count > 5)
            {
                hm.AddTen();
                await Task.Delay(500);
            }

            for (int j=0; j < codeList.Count; j++)
            {
                await hm.DoInputCode(j+1, codeList[j]);
                if(j == 9)
                {
                    hm.Charge();
                    codeList.RemoveRange(0, 10);
                }
            }

            if (codeList.Count > 0)
            {
                hm.Charge();
                codeList.Clear();
            }
        }

        /// <summary>
        /// 동작안하고 있음;;
        /// </summary>
        private void Charge()
        {
            var els = HtmlUtils.GetElementsByClassName(doc, "btnCharge");
            if (els.Count < 1)
            {
                Console.WriteLine("Failed to find Charge Button");
                return;
            }

            els[0].InvokeMember("click");
        }


        private async Task DoInputCode(int idx, HMCode code)
        {
            var pwdEl = doc.GetElementById($"pinNo1_{idx}");
            pwdEl.Focus();

            for(int j=0; j < code.pinNums.Count; j++)
            {
                pwdEl = doc.GetElementById($"pinNo{j+1}_{idx}");
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
