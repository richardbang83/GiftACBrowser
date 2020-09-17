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
        public static HtmlElement GetElementsByClass(HtmlDocument doc, string type, string className)
        {
            var buttons = doc.GetElementsByTagName(type);

            foreach (HtmlElement button in buttons)
            {
                if (button.GetAttribute("className") == className)
                {
                    return button;
                }
            }
            return null;
        }




        /// <summary>
        /// Make alert dom element and added
        /// </summary>
        /// <param name="web"></param>
        public static void DisableAlertPopup(WebBrowser web)
        {
            HtmlElement head = web.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptEl = web.Document.CreateElement("script");
            scriptEl.SetAttribute("text", "window.alert = function () { }; window.confirm=function () { };");
            head.AppendChild(scriptEl);
        }

    }
}
