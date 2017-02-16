using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.Commands.Interfaces;
using OpenQA.Selenium.Interactions;
using WbTstr.Utilities.Constants;
using WbTstr.Proxies.Interfaces;
using WbTstr.Proxies;
using WbTstr.Proxies.Extensions;
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
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            if (clickType == default(MouseClick)) throw new ArgumentException(nameof(clickType));

            _selector = selector;
            _clickType = clickType;
        }

        public ClickCommand(IElement element, MouseClick clickType)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            if (clickType == default(MouseClick)) throw new ArgumentException(nameof(clickType));

            _element = element;
            _clickType = clickType;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            if (webDriverObj == null) throw new ArgumentNullException(nameof(webDriverObj));
            var webDriver = webDriverObj as IWebDriver;

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
