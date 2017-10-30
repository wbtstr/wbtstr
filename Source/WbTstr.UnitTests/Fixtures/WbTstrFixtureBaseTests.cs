using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Configuration.WebDrivers.Exceptions;
using WbTstr.Fixtures;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Recorders.Interfaces;
using WbTstr.Session.Trackers.Interfaces;

namespace WbTstr.UnitTests.Fixtures
{
    [TestFixture]
    public class WbTstrFixtureBaseTests
    {
        public class DerivedFromWbTstrFixture : WbTstrFixture
        {

        }

        [TestCase]
        public void Constructor_NoAttributePresent_ThrowsMissingWebDriverConfigException()
        {
            // Arrange

            // Act
            TestDelegate action = () => new DerivedFromWbTstrFixture();

            // Assert
            Assert.Throws<MissingWebDriverConfigException>(action);
        }
    }
}
