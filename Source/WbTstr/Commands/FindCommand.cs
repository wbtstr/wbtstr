using OpenQA.Selenium;
using System;
using WbTstr.Commands.Interfaces;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.Commands
{
    public class FindCommand : IReturnCommand<IElement>
    {
        private readonly string _selector;

        public FindCommand(string selector)
        {
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));
        }

        /*-------------------------------------------------------------------*/

        public IElement Execute(object webDriverObj)
        {
            if (webDriverObj == null) throw new ArgumentNullException(nameof(_selector));
            var webDriver = webDriverObj as IWebDriver;

            var webElement = webDriver?.FindElement(By.CssSelector(_selector));
            return new Element(webElement, _selector);
        }

        public override string ToString()
        {
            return $"Finding element by '{_selector}'";
        }
    }
}
