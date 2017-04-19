using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands.Interfaces;
using WbTstr.WebDrivers;

namespace WbTstr.Commands.Abstracts
{
    internal abstract class WbTstrActionCommand : IActionCommand
    {
        public void Execute(object webDriverObj)
        {
            var webDriver = WebDriverUtilities.ObjectToWebDriver(webDriverObj);
            Execute(webDriver);
        }

        protected abstract void Execute(IWebDriver webDriver);
    }
}
