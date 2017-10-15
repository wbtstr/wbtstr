using OpenQA.Selenium;
using System.Linq;
using System.Collections.Generic;
using WbTstr.Commands.Abstracts;
using WbTstr.WebDrivers;
using WbTstr.WebDrivers.Interfaces;
using WebCookie = OpenQA.Selenium.Cookie;
using ProxyCookie = WbTstr.Proxies.Cookie;
using WbTstr.Proxies.Interfaces;

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

            page.Cookies = new List<WebCookie>(cookies.AllCookies)
                .Select(x => new ProxyCookie(x)).ToDictionary(x => x.Name, x => (ICookie)x);

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
