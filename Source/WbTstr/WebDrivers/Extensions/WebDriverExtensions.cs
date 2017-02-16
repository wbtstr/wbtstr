using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.WebDrivers.Extensions
{
    public static class WebDriverExtensions
    {
        internal static IWebElement FindElementBySelector(this IWebDriver webDriver, string selector)
        {
            if (string.IsNullOrEmpty(selector))
            {
                return null;
            }

            return webDriver.FindElement(By.CssSelector(selector));
        }
    }
}
