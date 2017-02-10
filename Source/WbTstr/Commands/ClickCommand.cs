using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.Commands.Interfaces;
using OpenQA.Selenium.Interactions;

namespace WbTstr.Commands
{
    internal class ClickCommand : ICommand
    {
        private readonly string _selector;
        private readonly bool _isDoubleClick;

        public ClickCommand(string selector, bool isDoubleClick)
        {
            _selector = selector;
            _isDoubleClick = isDoubleClick;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = webDriverObj as IWebDriver;
            var webElement = webDriver?.FindElement(By.CssSelector(_selector));

            var interaction = new Actions(webDriver);

            interaction = _isDoubleClick ? interaction.DoubleClick(webElement) : interaction.Click(webElement);
            interaction.Build().Perform();
        }

        public override string ToString()
        {
            return (_isDoubleClick ? "Double click" : "Click") + $" on {_selector}";
        }
    }
}
