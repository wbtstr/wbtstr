using System.Linq;
using NUnit.Framework;
using WbTstr.Fixtures.Attributes;
using WbTstr.WebDrivers.Constants;
using WbTstr.Utilities;
using System;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.IntegrationTests.SimpleWbTstrFixture
{
    [TestFixture]
    [WebDriverConfig(WebDriverType.Chrome, WebDriverScope.Test)]
    public class DerivedFromSimpleFixture : Fixtures.SimpleWbTstrFixture
    {
        private ICookie _loginCookie;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // string domain = "http://github.com";
            string name = "asdfasdf";
            // string path = "/";
            string value = "Hello World!";

            _loginCookie = CookieFactory.Create(name, value);
        }

        [TestCase]
        public void TestMethod1()
        {
            I.NavigateTo("http://github.com")
                .SetCookie(_loginCookie)
                .Wait(seconds: 1)
                .CapturePage(out var page);

            // Act
            Assert.IsNotEmpty(page.Cookies);

            // Arrange

            //// Act
            //I.NavigateTo("mirabeau.nl")
            //    .ClickOn("#contact")
            //    .FindOnPage("#element", out var special)
            //    .FindMultipleOnPage("#elements", out var elements)
            //    .CapturePage(out var page1)
            //    .ClickOn("#more")
            //    .CapturePage(out var page2);

            //// Assert
            //Assert.Contains(special, elements as ICollection);
            //Assert.AreEqual(page1.InitialHTML, page2.InitialHTML);
        }

        [TestCase]
        public void TestMethod2()
        {
            I.Wait(seconds: 3);
            I.MaximizeWindow();
            Assert.True(1 == 1);

            // Arrange
            //const string mirabeauUrl = "https://github.com/wbtstr/wbtstr";
            //const string mirabeauTitle = "GitHub - wbtstr/wbtstr: The uncomplicated test automation framework.";

            //// Act
            //I.NavigateTo("https://github.com/")
            //    .Type("username??")
            //    .ResizeWindow(1600, 1050)
            //    .WaitUntil(() => I.FindOnPage(".header-search-input").Displayed)
            //    .Focus(".header-search-input")
            //    .Wait(seconds: 3)
            //    .Type("wbtstr.net", ".header-search-input")
            //    .Wait(seconds: 3)
            //    .MaximizeWindow()
            //    .Type("wbtstr" + Keys.Enter, ".header-search-input", true)
            //    .Wait(seconds: 3)
            //    .Hover(".repo-list a:first-child")
            //    .Wait(seconds: 3)
            //    .ClickOn(".repo-list a:first-child")
            //    .TakeScreenshot();

            //IElement md = I.FindOnPage(".markdown-body");
            //string mdTagName = md.TagName;

            //ICollection<IElement> h1 = I.FindMultipleOnPage("h1");
            //Assert.True(h1.Count >= 0);

            //IElement b = I.ExecuteJs<IElement>("return window.document.body");
            //string bTagName = I.ExecuteJs<string>("return window.document.body.tagName");
            //long bChildElementCount = I.ExecuteJs<long>("return window.document.body.childElementCount");
            //bool bHasAttributes = I.ExecuteJs<bool>("return window.document.body.hasAttributes()");

            //// Assert
            //var page = CapturePage();
            //Assert.AreEqual(mirabeauTitle, page.Title);
            //Assert.AreEqual(mirabeauUrl, page.Url);
            //Assert.AreEqual(b.TagName.ToUpper(), bTagName.ToUpper());
            //Assert.NotZero(bChildElementCount);
            //Assert.IsTrue(bHasAttributes);
        }
    }
}
