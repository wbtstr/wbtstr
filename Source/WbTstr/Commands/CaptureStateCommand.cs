using OpenQA.Selenium;
using System;
using WbTstr.Commands.Abstracts;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;
using WbTstr.WebDrivers;
using WbTstr.WebDrivers.Exceptions;
using WbTstr.WebDrivers.Interfaces;

namespace WbTstr.Commands
{
    internal class CaptureStateCommand : WbTstrReturnCommand<IWebDriverState>
    {
        public CaptureStateCommand()
        {
        }

        /*-------------------------------------------------------------------*/

        protected override IWebDriverState Execute(IWebDriver webDriver)
        {
            return new WebDriverState(webDriver);
        }

        public override string ToString()
        {
            return $"Capturing state.";
        }
    }
}
