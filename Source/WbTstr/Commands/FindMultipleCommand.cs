using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using WbTstr.Commands.Abstracts;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.Commands
{
    internal class FindMultipleCommand : WbTstrReturnCommand<ICollection<IElement>>
    {
        private readonly string _selector;

        public FindMultipleCommand(string selector)
        {
            if (selector == null) throw new ArgumentNullException();

            _selector = !string.IsNullOrWhiteSpace(selector) ? selector : throw new ArgumentException(nameof(selector));
        }

        /*-------------------------------------------------------------------*/

        protected override ICollection<IElement> Execute(IWebDriver webDriver)
        {
            try
            {
                var webElements = webDriver.FindElements(By.CssSelector(_selector));
                return webElements.Select(x => new ElementProxy(x, _selector)).ToArray();
            }
            catch (NoSuchElementException)
            {
                throw new ElementNotFoundException($"Could not find element by CSS selector: {_selector}");
            }
        }

        public override string ToString()
        {
            return $"Finding element by '{_selector}'";
        }
    }
}
