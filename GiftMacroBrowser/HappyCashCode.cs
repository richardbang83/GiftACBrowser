using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GiftACBrowser
{
    public class HappyCashCode
    {
        public List<string> pinNums = new List<string>();

        public string issuedate;
        public HappyCashCode()
        {
        }


        /// <summary>
        /// 입력받은 문자열이 cash code의 패턴인지를 확인함.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool parseCode(string strCode, out List<HappyCashCode> codeList)
        {
            Regex regex = new Regex(@"([0-9]{4})-([0-9]{4})-([0-9]{4})-([0-9]{4})_([0-9]{8})");
            var trimStr= strCode.Replace(" ", "");
            MatchCollection matchCodes = regex.Matches(trimStr);

            codeList = new List<HappyCashCode>();

            if (matchCodes.Count > 0)
            {
                foreach (Match code in matchCodes)
                {
                    HappyCashCode hc = new HappyCashCode();
                    for (int i=0; i < 4; i++)
                    {
                        hc.pinNums.Add($"{code.Groups[i+1]}");
                    }
                    hc.issuedate = $"{code.Groups[5]}";

                    codeList.Add(hc);
                }

                return true;
            }

            return false;
        }
    }
}
