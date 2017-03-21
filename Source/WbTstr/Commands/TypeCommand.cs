using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WbTstr.Commands.Interfaces;
using WbTstr.Proxies.Interfaces;
using WbTstr.Proxies.Extensions;
using WbTstr.WebDrivers.Extensions;

namespace WbTstr.Commands
{
    public class TypeCommand : IActionCommand
    {
        private readonly string _text;
        private readonly string _selector;
        private readonly IElement _element;
        private readonly bool _clear;

        public TypeCommand(string text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public TypeCommand(string text, string selector, bool clear)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));
            _clear = clear;
        }

        public TypeCommand(string text, IElement element, bool clear)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _element = element ?? throw new ArgumentNullException(nameof(element));
            _clear = clear;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            if (webDriverObj == null) throw new ArgumentNullException(nameof(webDriverObj));
            var webDriver = webDriverObj as IWebDriver;

            var webElement = _element?.AsWebElement() ?? webDriver.FindElementBySelector(_selector);
            if (_clear) {
                webElement?.Clear();
            }

            webElement?.SendKeys(_text);
        }

        public override string ToString()
        {
            return $"Type '{_text}'";
        }
    }
}
