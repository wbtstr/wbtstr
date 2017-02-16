using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands.Interfaces;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.Commands
{
    public class FocusCommand : IActionCommand
    {
        private readonly string _selector;
        private readonly IElement _element;

        public FocusCommand(string selector)
        {
            _selector = selector;
        }

        public FocusCommand(IElement element)
        {
            _element = element;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            if (webDriverObj == null) throw new ArgumentNullException(nameof(webDriverObj));
            var webDriver = webDriverObj as IWebDriver;

            IWebElement webElement;
            if (_element != null)
            {
                webElement = Element.AsWebElement(_element);
            }
            else
            {
                webElement = webDriver.FindElement(By.CssSelector(_selector));
            }

            RemoteWebElement element = (RemoteWebElement)webElement;
            var viewPosition = element.LocationOnScreenOnceScrolledIntoView;

            element.Click();
        }
    }
}
