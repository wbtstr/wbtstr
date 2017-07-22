using OpenQA.Selenium;
using System.Collections.Specialized;
using System.Configuration;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.WebDrivers.Constants;
using WbTstr.Configuration.WebDrivers.Options;
using System;

namespace WbTstr.Configuration.WebDrivers
{
    public class ChromeWebDriverConfig : IWebDriverConfig
    {
        public WebDriverType Type { get; } = WebDriverType.Chrome;

        public ChromeWebDriverOptions Options { get; set; }
    }
}
