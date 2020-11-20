using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MSHTML;

namespace GiftACBrowser
{
    /// <summary>
    /// Enables IE WebBrowser control to evaluate XPath queries 
    /// by injecting http://svn.coderepos.org/share/lang/javascript/javascript-xpath/trunk/release/javascript-xpath-latest-cmp.js
    /// and to return XPath queries results to the calling C# code as strongly typed
    /// mshtml.IHTMLElement and IEnumerable<mshtml.IHTMLElement>
    /// </summary>
    public class WebBrowserControlXPathQueriesProcessor
    {
        private System.Windows.Forms.WebBrowser _webBrowser;
        public WebBrowserControlXPathQueriesProcessor(System.Windows.Forms.WebBrowser webBrowser)
        {
            _webBrowser = webBrowser;
            injectScripts();
        }

        private void injectScripts()
        {
            // Thanks to: http://stackoverflow.com/questions/7998996/how-to-inject-javascript-in-webbrowser-control

            HtmlElement head = _webBrowser.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptEl = _webBrowser.Document.CreateElement("script");
            MSHTML.IHTMLScriptElement element = (MSHTML.IHTMLScriptElement)scriptEl.DomElement;
            element.src = "http://svn.coderepos.org/share/lang/javascript/javascript-xpath/trunk/release/javascript-xpath-latest-cmp.js";
            head.AppendChild(scriptEl);

            string javaScriptText = @"
                    function GetElements (XPath) {
                            var xPathRes = document.evaluate ( XPath, document, null, XPathResult.ORDERED_NODE_ITERATOR_TYPE, null);              
                            var nextElement = xPathRes.iterateNext ();
                            var elements = new Object();
                            var elementIndex = 1;
                            while (nextElement) {
                            elements[elementIndex++] = nextElement;
                            nextElement = xPathRes.iterateNext ();
                            }
                        elements.length = elementIndex -1;
                        return elements;
                        };
                   ";
            scriptEl = _webBrowser.Document.CreateElement("script");
            element = (MSHTML.IHTMLScriptElement)scriptEl.DomElement;
            element.text = javaScriptText;
            head.AppendChild(scriptEl);
        }

        /// <summary>
        /// Gets Html element's mshtml.IHTMLElement object instance using XPath query
        /// </summary>
        public MSHTML.IHTMLElement GetHtmlElement(string xPathQuery)
        {
            string code = string.Format("document.evaluate('{0}', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;", xPathQuery);
            return _webBrowser.Document.InvokeScript("eval", new object[] { code }) as MSHTML.IHTMLElement;
        }

        /// <summary>
        /// Gets Html elements' IEnumerable<mshtml.IHTMLElement> object instance using XPath query
        /// </summary>
        public IEnumerable<MSHTML.IHTMLElement> GetHtmlElements(string xPathQuery)
        {
            // Thanks to: http://stackoverflow.com/questions/5278275/accessing-properties-of-javascript-objects-using-type-dynamic-in-c-sharp-4
            var comObject = _webBrowser.Document.InvokeScript("eval", new object[] { string.Format("GetElements('{0}')", xPathQuery) });
            Type type = comObject.GetType();
            int length = (int)type.InvokeMember("length", BindingFlags.GetProperty, null, comObject, null);

            for (int i = 1; i <= length; i++)
            {
                yield return type.InvokeMember(i.ToString(), BindingFlags.GetProperty, null, comObject, null) as MSHTML.IHTMLElement;
            }
        }
    }
}
