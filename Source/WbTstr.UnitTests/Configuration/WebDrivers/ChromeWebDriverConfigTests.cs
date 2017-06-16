using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using WbTstr.Configuration.WebDrivers;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.UnitTests.Configuration.WebDrivers
{
    [TestFixture]
    public class ChromeWebDriverConfigTests
    {
        private ChromeWebDriverConfig _defaultConfig;

        [SetUp]
        public void SetUp()
        {
            _defaultConfig = new ChromeWebDriverConfig();
        }

        [TestCase]
        public void Type_GetTypeProperty_ReturnsChromeType()
        {
            // Arrange
            var expected = WebDriverType.Chrome;

            // Act
            var actual = _defaultConfig.Type;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
