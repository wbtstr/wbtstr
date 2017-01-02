using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    internal class ClickCommand : ICommand
    {
        private readonly string _selector;

        public ClickCommand(string selector)
        {
            _selector = selector;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = webDriverObj as IWebDriver;
            var webElement = webDriver?.FindElement(By.CssSelector(_selector));
            
            webElement?.Click();
        }

        public override string ToString()
        {
            return $"Click on {_selector}";
        }
    }
}
