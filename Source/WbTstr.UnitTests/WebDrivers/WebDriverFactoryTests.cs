using System;
using NUnit.Framework.Internal;
using NUnit.Framework;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.WebDrivers;
using WbTstr.UnitTests._Stubs;

namespace WbTstr.UnitTests.WebDrivers
{
    [TestFixture]
    public class WebDriverFactoryTests
    {
        [TestCase]
        public void CreateFromConfig_NullConfig_ThrowsArgumentNullException()
        {
            // Arrange
            IWebDriverConfig config = null;

            // Act
            TestDelegate action = () => WebDriverFactory.CreateFromConfig(config);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void CreateFromConfig_WhenNoneWebDriver_ThrowArgumentException()
        {
            // arrange
            IWebDriverConfig config = new NoneWebDriverConfigStub();

            // act
            TestDelegate action = () => WebDriverFactory.CreateFromConfig(config);

            // assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
