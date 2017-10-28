using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using WbTstr.Commands.Abstracts;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;
using WbTstr.WebDrivers;
using WbTstr.WebDrivers.Interfaces;
using Cookie = OpenQA.Selenium.Cookie;

namespace WbTstr.Commands
{
    internal class CapturePageCommand : WbTstrReturnCommand<IPage>
    {
        public CapturePageCommand()
        {
        }

        /*-------------------------------------------------------------------*/

        protected override IPage Execute(IWebDriver webDriver)
        {
            var cookies = webDriver.Manage().Cookies;
            var window = webDriver.Manage().Window;
            var logs = webDriver.Manage().Logs;

            var page = new Page()
            {
                Title = webDriver.Title,
                Url = webDriver.Url,
                InitialHTML = webDriver.PageSource,
                Size = window.Size,
            };

            page.Cookies = new List<Cookie>(cookies.AllCookies)
                .Select(x => new CookieProxy(x)).ToDictionary(x => x.Name, x => (ICookie)x);

            page.Console = new List<LogEntry>(logs.GetLog("browser"))
                .OrderBy(x => x.Timestamp).Select(x => x.Message).ToList();

            var htmlElement = webDriver.FindElement(By.TagName("html"));
            page.CurrentHTML = htmlElement?.GetAttribute("outerHTML");

            return page;
        }

        public override string ToString()
        {
            return $"Capturing page.";
        }
    }
}
