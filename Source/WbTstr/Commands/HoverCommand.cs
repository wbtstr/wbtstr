using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using WbTstr.Commands.Interfaces;
using WbTstr.Proxies.Extensions;
using WbTstr.Proxies.Interfaces;
using WbTstr.WebDrivers;
using WbTstr.WebDrivers.Extensions;

namespace WbTstr.Commands
{
    public class HoverCommand : IActionCommand
    {
        private readonly string _selector;
        private readonly IElement _element;

        public HoverCommand(string selector)
        {
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));
        }

        public HoverCommand(IElement element)
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = WebDriverUtilities.ObjectToWebDriver(webDriverObj);
            var webElement = _element?.AsWebElement() ?? webDriver.FindElementBySelector(_selector);

            if (webElement != null)
            {
                var interaction = new Actions(webDriver);
                interaction.MoveToElement(webElement).Perform();
            }
        }

        public override string ToString()
        {
            return $"Hovering on element '{_selector ?? _element.Selector ?? "?"}'";
        }
    }
}
