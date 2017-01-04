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
using WbTstr.WebDrivers.Constants;

namespace WbTstr.IntegrationTests.Fixtures.Auxiliaries
{
    [WebDriverConfig("Chrome")]
    public class DerivedFromSimpleFixture : SimpleFixture<SequentialSessionPerformer>
    {
        public void TestMethod()
        {
            // Arrange
            const string mirabeauUrl = "https://www.mirabeau.nl/";
            const string mirabeauTitle = "Mirabeau - digital agency | AHEAD IN A DIGITAL WORLD";

            // Act
            I.NavigateTo("http://www.google.com")
                .Type("mirabeau")
                .Wait(seconds: 3)
                .ClickOn(".r > a")
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
