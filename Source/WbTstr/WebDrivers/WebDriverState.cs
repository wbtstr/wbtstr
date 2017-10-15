using System;
using OpenQA.Selenium;
using WbTstr.WebDrivers.Interfaces;

namespace WbTstr.WebDrivers
{
    public class WebDriverState : IWebDriverState
    {
        private readonly IWebDriver _webDriver;

        internal WebDriverState(IWebDriver webDriver)
        {
            _webDriver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        /* Properties -------------------------------------------------------*/

        public string Url => _webDriver.Url;

        public string Title => _webDriver.Title;
    }
}
