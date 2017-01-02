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

namespace WbTstr.IntegrationTests.Fixtures.Auxiliaries
{
    [WebDriverConfig("Chrome")]
    public class DerivedFromSimpleFixture : SimpleFixture<SequentialSessionPerformer>
    {
        public void TestMethod()
        {
            // Arrange
            const string firstResultUrl = "https://www.mirabeau.nl/";

            // Act
            I.NavigateTo("http://www.google.com")
                .Type("mirabeau")
                .Wait(seconds: 3)
                .ClickOn(".r > a");

            // Assert
            I.CheckThat(url: firstResultUrl);
        }
    }
}
