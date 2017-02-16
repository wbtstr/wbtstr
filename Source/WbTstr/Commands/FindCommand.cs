using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
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
            _selector = selector;
        }

        /*-------------------------------------------------------------------*/

        public IElement Execute(object webDriverObj)
        {
            var webDriver = webDriverObj as IWebDriver;

            var webElement = webDriver?.FindElement(By.CssSelector(_selector));
            return new Element(webElement);
        }
    }
}
