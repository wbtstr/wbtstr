using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using WbTstr.Commands.Abstracts;
using WbTstr.Proxies.Extensions;
using WbTstr.Proxies.Interfaces;
using WbTstr.WebDrivers.Extensions;

namespace WbTstr.Commands
{
    internal class FocusCommand : WbTstrActionCommand
    {
        private readonly string _selector;
        private readonly IElement _element;

        public FocusCommand(string selector)
        {
            if (selector == null) throw new ArgumentNullException();

            _selector = !string.IsNullOrWhiteSpace(selector) ? selector : throw new ArgumentException(nameof(selector));
        }

        public FocusCommand(IElement element)
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
        }

        /* Methods ----------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            var webElement = _element?.AsWebElement() ?? webDriver.FindElementBySelector(_selector);

            if (webElement != null)
            {
                RemoteWebElement element = (RemoteWebElement)webElement;
                var viewPosition = element.LocationOnScreenOnceScrolledIntoView;

                element.Click();
            }
        }

        public override string ToString()
        {
            return $"Focussing on element '{_selector ?? _element.Selector ?? "?"}'";
        }
    }
}
