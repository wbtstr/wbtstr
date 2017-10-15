using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using WbTstr.Fixtures.Attributes;
using WbTstr.Proxies.Interfaces;
using WbTstr.Utilities.Constants;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.IntegrationTests.SimpleWbTstrFixture
{
    [TestFixture]
    [WebDriverConfig(WebDriverType.Chrome)]
    public class DerivedFromSimpleFixture : Fixtures.SimpleWbTstrFixture
    {
        [TestCase]
        public void TestMethod()
        {
            // Arrange
            const string mirabeauUrl = "https://github.com/wbtstr/wbtstr";
            const string mirabeauTitle = "GitHub - wbtstr/wbtstr: The uncomplicated test automation framework.";

            // Act
            I.NavigateTo("https://github.com/")
                .Type("username??")
                .ResizeWindow(1600, 1050)
                .WaitUntil(() => I.FindOnPage(".header-search-input").Displayed)
                .Focus(".header-search-input")
                .Wait(seconds: 3)
                .Type("wbtstr.net", ".header-search-input")
                .Wait(seconds: 3)
                .MaximizeWindow()
                .Type("wbtstr" + Keys.Enter, ".header-search-input", true)
                .Wait(seconds: 3)
                .Hover(".repo-list a:first-child")
                .Wait(seconds: 3)
                .ClickOn(".repo-list a:first-child")
                .TakeScreenshot();

            IElement md = I.FindOnPage(".markdown-body");
            string mdTagName = md.TagName;

            ICollection<IElement> h1 = I.FindMultipleOnPage("h1");
            Assert.True(h1.Count >= 0);

            IElement b = I.ExecuteJs<IElement>("return window.document.body");
            string bTagName = I.ExecuteJs<string>("return window.document.body.tagName");
            long bChildElementCount = I.ExecuteJs<long>("return window.document.body.childElementCount");
            bool bHasAttributes = I.ExecuteJs<bool>("return window.document.body.hasAttributes()");

            // Assert
            var page = CapturePage();
            Assert.AreEqual(mirabeauTitle, page.Title);
            Assert.AreEqual(mirabeauUrl, page.Url);
            Assert.AreEqual(b.TagName.ToUpper(), bTagName.ToUpper());
            Assert.NotZero(bChildElementCount);
            Assert.IsTrue(bHasAttributes);
        }
    }
}
