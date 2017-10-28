using NUnit.Framework;
using WbTstr.Fixtures.Attributes;
using WbTstr.WebDrivers.Constants;
using WbTstr.Proxies.Interfaces;
using WbTstr.Fixtures;
using OpenQA.Selenium;

namespace WbTstr.IntegrationTests.Fixtures
{
    [TestFixture]
    [WebDriverConfig(WebDriverType.Chrome)]
    public class WbTstrFixtureTests : WbTstrFixture
    {
        [TestCase]
        public void TestMethod2()
        {
            //Arrange
            const string mirabeauUrl = "https://github.com/wbtstr/wbtstr";
            const string mirabeauTitle = "GitHub - wbtstr/wbtstr: The uncomplicated test automation framework.";

            // Act
            I.Open("https://github.com/")
                .Type("username??")
                .ResizeWindow(1600, 1050)
                .WaitUntil(() => I.Find(".header-search-input").Displayed)
                .Focus(".header-search-input")
                .Wait(seconds: 3)
                .Enter("wbtstr.net").In(".header-search-input")
                .Wait(seconds: 3)
                .MaximizeWindow()
                .Enter("wbtstr" + Keys.Enter).In(".header-search-input")
                .Wait(seconds: 3)
                .Hover(".repo-list a:first-child")
                .Wait(seconds: 3)
                .Click(".repo-list a:first-child")
                .TakeScreenshot();

            IElement md = I.Find(".markdown-body");
            string mdTagName = md.TagName;

            var h1 = I.FindMultiple("h1");
            Assert.True(h1.Count >= 0);

            IElement b = I.ExecuteJs<IElement>("return window.document.body");
            string bTagName = I.ExecuteJs<string>("return window.document.body.tagName");
            long bChildElementCount = I.ExecuteJs<long>("return window.document.body.childElementCount");
            bool bHasAttributes = I.ExecuteJs<bool>("return window.document.body.hasAttributes()");

            // Assert
            var page = I.CapturePage();
            Assert.AreEqual(mirabeauTitle, page.Title);
            Assert.AreEqual(mirabeauUrl, page.Url);
            Assert.AreEqual(b.TagName.ToUpper(), bTagName.ToUpper());
            Assert.NotZero(bChildElementCount);
            Assert.IsTrue(bHasAttributes);
        }
    }
}
