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
        internal Element(IWebElement webElement)
        {
            if (webElement == null) throw new ArgumentNullException(nameof(webElement));

            InnerWebElement = webElement;
        }

        internal Element(IWebElement webElement, string selector)
        {
            if (webElement == null) throw new ArgumentNullException(nameof(webElement));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            InnerWebElement = webElement;
            Selector = !string.IsNullOrWhiteSpace(selector) ? selector : throw new ArgumentException(nameof(selector));
        }

        /* Methods ----------------------------------------------------------*/

        internal static IWebElement AsWebElement(IElement element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));

            return (element as Element)?.InnerWebElement;
        }

        /* Properties -------------------------------------------------------*/

        internal IWebElement InnerWebElement { get; }

        public string Selector { get; }

        public string TagName => InnerWebElement.TagName;

        public string Text => InnerWebElement.Text;

        public bool Enabled => InnerWebElement.Enabled;

        public bool Selected => InnerWebElement.Selected;

        public bool Displayed => InnerWebElement.Displayed;

        public string GetAttribute(string name) => InnerWebElement.GetAttribute(name);

        public string GetCssValue(string name) => InnerWebElement.GetCssValue(name);

        public int Height => InnerWebElement.Size.Width;

        public int Width => InnerWebElement.Size.Width;

        public int UpperLeftCornerX => InnerWebElement.Location.X;

        public int UpperLeftCornerY => InnerWebElement.Location.Y;
    }
}
