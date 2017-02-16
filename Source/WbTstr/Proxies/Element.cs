using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.Proxies
{
    public class Element : IElement
    {
        private readonly IWebElement _webElement;

        internal Element(IWebElement webElement)
        {
            _webElement = webElement;
        }

        /* Methods ----------------------------------------------------------*/

        internal static IWebElement AsWebElement(IElement element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));

            return (element as Element).InnerWebElement;
        }

        /* Properties -------------------------------------------------------*/

        internal IWebElement InnerWebElement => _webElement;

        public string TagName => _webElement.TagName;

        public string Text => _webElement.Text;

        public bool Enabled => _webElement.Enabled;

        public bool Selected => _webElement.Selected;

        public bool Displayed => _webElement.Displayed;

        public string GetAttribute(string name) => _webElement.GetAttribute(name);

        public string GetCssValue(string name) => _webElement.GetCssValue(name);

        public int Height => _webElement.Size.Width;

        public int Width => _webElement.Size.Width;

        public int UpperLeftCornerX => _webElement.Location.X;

        public int UpperLeftCornerY => _webElement.Location.Y;
    }
}
