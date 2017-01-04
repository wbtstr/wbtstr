using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WbTstr.WebDrivers
{
    public class WebDriverState
    {
        private readonly IWebDriver _webDriver;

        internal WebDriverState(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        /* Properties -------------------------------------------------------*/

        public string Url => _webDriver.Url;

        public string Title => _webDriver.Title;
    }
}
