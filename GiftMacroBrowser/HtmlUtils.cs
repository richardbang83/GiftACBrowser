using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftMacroBrowser
{
    public static class HtmlUtils
    {
        public static List<HtmlElement> GetElementsByClassName(HtmlDocument doc, string classname)
        {
            var byTagName = doc.GetElementsByTagName("a");
            HtmlElement fndEl = null;
            List<HtmlElement> list = new List<HtmlElement>();
            foreach (HtmlElement element in byTagName)
            {
                if (element.GetAttribute("className").Contains(classname))
                {
                    fndEl = element;
                    list.Add(fndEl);

                }
            }

            return list;
        }


    }
}
