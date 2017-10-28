using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using WbTstr.Commands.Abstracts;
using WbTstr.Proxies.Extensions;
using WbTstr.Proxies.Interfaces;
using WbTstr.Utilities.Constants;
using WbTstr.WebDrivers.Extensions;

namespace WbTstr.Commands
{
    internal class ClickCommand : WbTstrActionCommand
    {
        private readonly string _selector;
        private readonly IElement _element;
        private readonly MouseClick _clickType;

        public ClickCommand(string selector, MouseClick clickType)
        {
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));
            _clickType = clickType != MouseClick.None ? clickType : throw new ArgumentException(nameof(clickType));
        }

        public ClickCommand(IElement element, MouseClick clickType)
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
            _clickType = clickType != MouseClick.None ? clickType : throw new ArgumentException(nameof(clickType));
        }

        /*-------------------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            var webElement = _element?.AsWebElement() ?? webDriver.FindElementBySelector(_selector);

            switch (_clickType)
            {
                case MouseClick.Single:
                    PerformSingleClickOnElement(webDriver, webElement);
                    break;
                case MouseClick.Double:
                    PerformDoubleClickOnElement(webDriver, webElement);
                    break;
                case MouseClick.Context:
                    PerformContextClickOnElement(webDriver, webElement);
                    break;
            }
        }

        public virtual void PerformSingleClickOnElement(IWebDriver webDriver, IWebElement webElement)
        {
            var interaction = new Actions(webDriver);

            interaction
                .Click(webElement)
                .Build()
                .Perform();
        }

        public virtual void PerformDoubleClickOnElement(IWebDriver webDriver, IWebElement webElement)
        {
            var interaction = new Actions(webDriver);

            interaction
                .DoubleClick(webElement)
                .Build()
                .Perform();
        }

        public virtual void PerformContextClickOnElement(IWebDriver webDriver, IWebElement webElement)
        {
            var interaction = new Actions(webDriver);

            interaction
                .ContextClick(webElement)
                .Build()
                .Perform();
        }

        public override string ToString()
        {
            string clickType = Enum.GetName(typeof(MouseClick), _clickType);
            return $"{clickType} click on {_selector}";
        }
    }
}
