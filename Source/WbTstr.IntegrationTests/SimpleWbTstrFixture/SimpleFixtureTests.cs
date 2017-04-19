using NUnit.Framework;
using WbTstr.Fixtures;
using WbTstr.Fixtures.Attributes;
using WbTstr.Proxies.Interfaces;
using WbTstr.Utilities.Constants;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.IntegrationTests.Fixtures
{
    [TestFixture]
    [WebDriverConfig(WebDriverType.Chrome)]
    public class DerivedFromSimpleFixture : SimpleWbTstrFixture
    {
        [Test, Ignore("")]
        public void TestMethod()
        {
            // Arrange
            const string mirabeauUrl = "https://github.com/wbtstr/wbtstr";
            const string mirabeauTitle = "GitHub - wbtstr/wbtstr: The uncomplicated test automation framework.";

            // Act
            I.NavigateTo("https://github.com/")
                .Type("username??")
                .ResizeWindow(1024, 720)
                .Focus(".header-search-input")
                .Wait(seconds: 3)
                .Type("wbtstr.net", ".header-search-input")
                .Wait(seconds: 3)
                .MaximizeWindow()
                .Type("wbtstr" + Keys.Enter, ".header-search-input", true)
                .Wait(seconds: 3)
                .Hover(".js-repo-list a:first-child")
                .Wait(seconds: 3)
                .ClickOn(".js-repo-list a:first-child")
                .TakeScreenshot();

            IElement md = I.FindOnPage(".markdown-body");
            string mdTagName = md.TagName;

            IElement b = I.ExecuteJs<IElement>("return window.document.body");
            string bTagName = I.ExecuteJs<string>("return window.document.body.tagName");
            long bChildElementCount = I.ExecuteJs<long>("return window.document.body.childElementCount");
            bool bHasAttributes = I.ExecuteJs<bool>("return window.document.body.hasAttributes()");

            // Assert
            Assert.AreEqual(b.TagName.ToUpper(), bTagName.ToUpper());
            Assert.NotZero(bChildElementCount);
            Assert.IsTrue(bHasAttributes);

            I.CheckThat(
                title: mirabeauTitle,
                url: mirabeauUrl
            );

            I.CheckThat(state => state.Title == mirabeauTitle);
            I.CheckThat(state => state.Url == mirabeauUrl);
        }
    }
}
