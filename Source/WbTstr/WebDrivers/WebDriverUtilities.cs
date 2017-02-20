using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.WebDrivers
{
    public static class WebDriverUtilities
    {
        internal static object WebDriverToObject(IWebDriver webDriver)
        {
            if (webDriver == null) throw new ArgumentNullException(nameof(webDriver));

            return webDriver as object;
        }

        internal static IWebDriver ObjectToWebDriver(object webDriverObj)
        {
            if (webDriverObj == null) throw new ArgumentNullException(nameof(webDriverObj));

            var webDriver = webDriverObj as IWebDriver;
            if (webDriver == null)
            {
                throw new ArgumentException(nameof(webDriver));
            }

            return webDriver;
        }
    }
}
