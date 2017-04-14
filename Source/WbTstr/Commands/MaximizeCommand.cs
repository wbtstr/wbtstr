using OpenQA.Selenium;
using System;
using System.Drawing;
using WbTstr.Commands.Interfaces;
using WbTstr.WebDrivers;

namespace WbTstr.Commands
{
    public class MaximizeCommand : IActionCommand
    {
        public MaximizeCommand()
        {
        }

        /*-------------------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = WebDriverUtilities.ObjectToWebDriver(webDriverObj);

            webDriver?.Manage().Window.Maximize();
        }

        public override string ToString()
        {
            return $"Maximize window";
        }
    }
}
