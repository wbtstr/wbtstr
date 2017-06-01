using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WbTstr.Configuration.WebDrivers;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.WebDrivers;

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
    }
}
