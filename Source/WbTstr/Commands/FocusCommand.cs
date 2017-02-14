using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    public class FocusCommand : ICommand
    {
        private readonly string _selector;

        public FocusCommand(string selector)
        {
            _selector = selector;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = webDriverObj as IWebDriver;

            RemoteWebElement element = (RemoteWebElement)webDriver.FindElement(By.CssSelector(_selector));
            var viewPosition = element.LocationOnScreenOnceScrolledIntoView;

            element.Click();
        }
    }
}
