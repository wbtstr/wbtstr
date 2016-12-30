using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WbTstr.Configuration.WebDrivers.Constants;
using WbTstr.Configuration.WebDrivers.Interfaces;

namespace WbTstr.WebDrivers
{
    internal static class WebDriverFactory
    {
        public static IWebDriver CreateFromConfig(IWebDriverConfig config)
        {
            IWebDriver webDriver;

            switch (config.Type)
            {
                case WebDriverType.Chrome:
                    webDriver = CreateChromeWebDriver(config);
                    break;
                default:
                    throw new ArgumentException($"WebDriver type not supported: {Enum.GetName(typeof(WebDriverType), config.Type)}");
            }

            return webDriver;
        }

        private static IWebDriver CreateChromeWebDriver(IWebDriverConfig config)
        {
            var options = new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService();
            var webDriver = new ChromeDriver(service, options);

            return webDriver;
        }
    }
}
