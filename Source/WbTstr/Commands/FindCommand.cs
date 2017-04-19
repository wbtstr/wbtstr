using OpenQA.Selenium;
using System;
using WbTstr.Commands.Abstracts;
using WbTstr.Commands.Interfaces;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;
using WbTstr.WebDrivers;

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
            var webElement = webDriver.FindElement(By.CssSelector(_selector));

            return new Element(webElement, _selector);
        }

        public override string ToString()
        {
            return $"Finding element by '{_selector}'";
        }
    }
}
