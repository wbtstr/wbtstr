using OpenQA.Selenium;
using System;
using System.Drawing;
using WbTstr.Commands.Abstracts;
using WbTstr.Commands.Interfaces;
using WbTstr.WebDrivers;

namespace WbTstr.Commands
{
    internal class MaximizeCommand : WbTstrActionCommand
    {
        public MaximizeCommand()
        {
        }

        /*-------------------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            webDriver.Manage().Window.Maximize();
        }

        public override string ToString()
        {
            return $"Maximize window";
        }
    }
}
