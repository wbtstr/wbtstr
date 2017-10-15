using OpenQA.Selenium;
using System.Collections.Generic;
using WbTstr.Commands.Abstracts;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;
using WbTstr.WebDrivers;
using WbTstr.WebDrivers.Interfaces;

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
            var options = webDriver.Manage();

            var page = new Page()
            {
                Title = webDriver.Title,
                Url = webDriver.Url,
                Source = webDriver.PageSource,
            };

            var cookies = new List<ICookie>();
            foreach (var webCookie in options.Cookies.AllCookies)
            {
                cookies.Add(new Proxies.Cookie(webCookie));
            }
            page.Cookies = cookies;

            return page;
        }

        public override string ToString()
        {
            return $"Capturing page.";
        }
    }
}
