using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using WbTstr.Commands.Interfaces;
using WbTstr.Proxies.Extensions;
using WbTstr.Proxies.Interfaces;
using WbTstr.Utilities.Constants;
using WbTstr.WebDrivers;
using WbTstr.WebDrivers.Extensions;

namespace WbTstr.Commands
{
    internal class ClickCommand : IActionCommand
    {
        private readonly string _selector;
        private readonly IElement _element;
        private readonly MouseClick _clickType;

        public ClickCommand(string selector, MouseClick clickType)
        {
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));
            _clickType = clickType != MouseClick.None ? clickType : throw new ArgumentException(nameof(clickType));

            if (string.IsNullOrWhiteSpace(selector))
            {
                throw new ArgumentException(nameof(selector));
            }
        }

        public ClickCommand(IElement element, MouseClick clickType)
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
            _clickType = clickType != MouseClick.None ? clickType : throw new ArgumentException(nameof(clickType));
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = WebDriverUtilities.ObjectToWebDriver(webDriverObj);
            var webElement = _element?.AsWebElement() ?? webDriver.FindElementBySelector(_selector);

            var interaction = new Actions(webDriver);
            switch (_clickType)
            {
                case MouseClick.Context:
                    interaction.ContextClick(webElement);
                    break;
                case MouseClick.Double:
                    interaction.DoubleClick(webElement);
                    break;
                case MouseClick.Single:
                default:
                    interaction.Click(webElement);
                    break;
            }
                
            interaction.Build().Perform();
        }

        public override string ToString()
        {
            string clickType = Enum.GetName(typeof(MouseClick), _clickType);
            return $"{clickType} click on {_selector}";
        }
    }
}
