using System;
using OpenQA.Selenium;

namespace WbTstr.WebDrivers
{
    public class WebDriverState
    {
        private readonly IWebDriver _webDriver;

        internal WebDriverState(IWebDriver webDriver)
        {
            if (webDriver == null) throw new ArgumentNullException(nameof(webDriver));

            _webDriver = webDriver;
        }

        /* Properties -------------------------------------------------------*/

        public string Url => _webDriver.Url;

        public string Title => _webDriver.Title;
    }
}
