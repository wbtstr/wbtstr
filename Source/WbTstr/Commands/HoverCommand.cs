using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands.Interfaces;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;
using WbTstr.Proxies.Extensions;
using WbTstr.WebDrivers.Extensions;

namespace WbTstr.Commands
{
    public class HoverCommand : IActionCommand
    {
        private readonly string _selector;
        private readonly IElement _element;

        public HoverCommand(string selector)
        {
            _selector = selector;
        }

        public HoverCommand(IElement element)
        {
            _element = element;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            if (webDriverObj == null) throw new ArgumentNullException(nameof(webDriverObj));
            var webDriver = webDriverObj as IWebDriver;

            var webElement = _element?.AsWebElement() ?? webDriver.FindElementBySelector(_selector);
            if (webElement != null)
            {
                var interaction = new Actions(webDriver);
                interaction.MoveToElement(webElement).Perform();
            }
        }
    }
}
