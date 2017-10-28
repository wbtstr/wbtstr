using OpenQA.Selenium;
using System;
using WbTstr.Commands.Abstracts;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.Commands
{
    internal class FindCommand : WbTstrReturnCommand<IElement>
    {
        private readonly string _selector;

        public FindCommand(string selector)
        {
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));
        }

        /*-------------------------------------------------------------------*/

        protected override IElement Execute(IWebDriver webDriver)
        {
            try
            {
                var webElement = webDriver.FindElement(By.CssSelector(_selector));
                return new ElementProxy(webElement, _selector);
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
