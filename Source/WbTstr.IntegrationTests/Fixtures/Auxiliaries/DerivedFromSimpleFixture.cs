using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Fixtures;
using WbTstr.Fixtures.Attributes;
using WbTstr.Proxies.Interfaces;
using WbTstr.Session.Performers;
using WbTstr.Session.Recorders;
using WbTstr.Session.Trackers;
using WbTstr.Utilities.Constants;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.IntegrationTests.Fixtures.Auxiliaries
{
    [WebDriverConfig("Chrome")]
    public class DerivedFromSimpleFixture : SimpleWbTstrFixture
    {
        public void TestMethod()
        {
            // Arrange
            const string mirabeauUrl = "https://github.com/wbtstr/wbtstr";
            const string mirabeauTitle = "GitHub - wbtstr/wbtstr: The uncomplicated test automation framework.";

            // Act
            I.NavigateTo("https://github.com/")
                .Resize(1920, 1080)
                .Focus(".header-search-input")
                .Wait(seconds: 3)
                .Type("wbtstr.net", ".header-search-input")
                .Wait(seconds: 3)
                .Type("wbtstr" + Keys.Enter, ".header-search-input", true)
                .Wait(seconds: 3)
                .Hover(".js-repo-list a:first-child")
                .Wait(seconds: 3)
                .ClickOn(".js-repo-list a:first-child")
                .TakeScreenshot();

            IElement md = I.FindOnPage(".markdown-body");
            string mdTagName = md.TagName;

            // Assert
            I.CheckThat(
                title: mirabeauTitle,
                url: mirabeauUrl
            );

            I.CheckThat(state => state.Title == mirabeauTitle);
            I.CheckThat(state => state.Url == mirabeauUrl);
        }
    }
}