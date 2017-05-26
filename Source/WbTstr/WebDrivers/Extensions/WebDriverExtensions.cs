using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.WebDrivers.Extensions
{
    public static class WebDriverExtensions
    {
        internal static IWebElement FindElementBySelector(this IWebDriver webDriver, string selector)
        {
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            if (string.IsNullOrEmpty(selector))
            {
                return null;
            }

            try
            {
                return webDriver.FindElement(By.CssSelector(selector));
            }
            catch (NoSuchElementException)
            {
                throw new ElementNotFoundException();
            }
        }
    }
}
