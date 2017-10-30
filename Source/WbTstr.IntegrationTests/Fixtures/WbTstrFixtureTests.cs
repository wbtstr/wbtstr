using NUnit.Framework;
using WbTstr.Fixtures.Attributes;
using WbTstr.WebDrivers.Constants;
using WbTstr.Proxies.Interfaces;
using WbTstr.Fixtures;
using OpenQA.Selenium;
using System.Linq;
using WbTstr.Utilities;

namespace WbTstr.IntegrationTests.Fixtures
{
    [TestFixture]
    [WebDriverConfig(WebDriverType.Chrome)]
    public class WbTstrFixtureTests : WbTstrFixture
    {
        [TestCase]
        public void TestMethod()
        {
            //Arrange
            const string mirabeauUrl = "https://github.com/wbtstr/wbtstr";
            const string mirabeauTitle = "GitHub - wbtstr/wbtstr: The uncomplicated test automation framework.";

            // Act
            I.Open("https://github.com/")
                .Open(UriParser.ParseWebUrl("https://github.com/"))
                .Type("username??")
                .ResizeWindow(1600, 1050)
                .CapturePage(out var snapshot1)
                .SetCookie(CookieFactory.Create(snapshot1.Cookies.Keys.First(), "Hello World!"))
                .SetCookie(snapshot1.Cookies.Keys.First(), "Hello World!")
                .WaitUntil(() => I.Find(".header-search-input").Displayed)
                .Focus(".header-search-input")
                .Find(".header-search-input", out var input)
                .Focus(input)
                .Wait(seconds: 1)
                .DeleteCookie(snapshot1.Cookies.Keys.First())
                .Enter("wbtstr.net").In(".header-search-input")
                .Append("!!!").In(".header-search-input")
                .DoubleClick(".header-search-input")
                .DoubleClick(input)
                .Wait(seconds: 1)
                .MaximizeWindow()
                .Find(".header-search-input", out var header)
                .Enter("wbtstr").In(header)
                .Append(Keys.Enter).In(header)
                .Wait(seconds: 1)
                .Hover(".repo-list a:first-child")
                .Find(".repo-list a:first-child", out var firstChild)
                .Hover(firstChild)
                .Wait(seconds: 1)
                .Click(".repo-list a:first-child")
                .TakeScreenshot()
                .RightClick("body")
                .Find("body", out var body)
                .RightClick(body);

            IElement md = I.Find(".markdown-body");
            string mdTagName = md.TagName;
            string mdSelector = md.Selector;
            string mdGetAttribute = md.GetAttribute("outerHTML");
            string mdGetCssValue = md.GetCssValue("height");
            int mdHeight = md.Height;
            int mdWidth = md.Width;
            int mdUpperLeftCornerX = md.UpperLeftCornerX;
            int mdUpperLeftCornerY = md.UpperLeftCornerY;
            string HTML = md.HTML;

            var h1 = I.FindMultiple("h1");
            Assert.True(h1.Count >= 0);

            IElement b = I.ExecuteJs<IElement>("return window.document.body");
            string bTagName = I.ExecuteJs<string>("return window.document.body.tagName");
            long bChildElementCount = I.ExecuteJs<long>("return window.document.body.childElementCount");
            bool bHasAttributes = I.ExecuteJs<bool>("return window.document.body.hasAttributes()");

            var page = I.CapturePage();
            var cookie = page.Cookies[page.Cookies.Keys.First()];
            var value = cookie.Value;
            var domain = cookie.Domain;
            var path = cookie.Path;
            var secure = cookie.Secure;
            var isHttpOnly = cookie.IsHttpOnly;
            var expiry = cookie.Expiry;

            // Assert
            Assert.AreEqual(mirabeauTitle, page.Title);
            Assert.AreEqual(mirabeauUrl, page.Url);
            Assert.AreEqual(b.TagName.ToUpper(), bTagName.ToUpper());
            Assert.NotZero(bChildElementCount);
            Assert.IsTrue(bHasAttributes);
        }
    }
}
