using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Fixtures;
using WbTstr.Fixtures.Attributes;
using WbTstr.Session.Performers;
using WbTstr.Session.Recorders;
using WbTstr.Session.Trackers;
using WbTstr.Utilities.Constants;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.IntegrationTests.Fixtures.Auxiliaries
{
    [WebDriverConfig("Chrome")]
    public class DerivedFromSimpleFixture : SimpleFixture<SequentialSessionPerformer>
    {
        public void TestMethod()
        {
            // Arrange
            const string mirabeauUrl = "https://github.com/wbtstr/wbtstr";
            const string mirabeauTitle = "GitHub - wbtstr/wbtstr: Advanced functional testing and automation framework.";

            // Act
            I.NavigateTo("https://github.com/")
                .Type("wbtstr.net", ".header-search-input")
                .Wait(seconds: 3)
                .Type("wbtstr" + Keys.Enter, ".header-search-input", true)
                .Wait(seconds: 3)
                .ClickOn(".js-repo-list a:first-child")
                .TakeScreenshot();

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