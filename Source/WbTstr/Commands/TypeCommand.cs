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
using WbTstr.Commands.Abstracts;

namespace WbTstr.Commands
{
    internal class TypeCommand : WbTstrActionCommand
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
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            _text = !string.IsNullOrEmpty(text) ? text : throw new ArgumentException(nameof(text));
            _selector = !string.IsNullOrWhiteSpace(selector) ? selector : throw new ArgumentException(nameof(selector));
            _clear = clear;
        }

        public TypeCommand(string text, IElement element, bool clear)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (element == null) throw new ArgumentNullException(nameof(element));

            _text = !string.IsNullOrEmpty(text) ? text : throw new ArgumentException(nameof(text));
            _element = element;
            _clear = clear;
        }

        /* Methods ----------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            var webElement = _element?.AsWebElement() ?? webDriver.FindElementBySelector(_selector);

            if (_clear) {
                webElement?.Clear();
            }

            webElement?.SendKeys(_text);
        }

        public override string ToString()
        {
            string selector = _element?.Selector ?? _selector;
            return $"Type '{_text}' in {selector}";
        }
    }
}
