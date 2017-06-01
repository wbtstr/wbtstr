using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using WbTstr.WebDrivers;

namespace WbTstr.UnitTests.WebDrivers
{
    [TestFixture]
    public class WebDriverUtilitiesTests
    {
        [TestCase]
        public void WebDriverToObject_NullWebDriver_ThrowsArgumentNullException()
        {
            // Arrange
            IWebDriver webDriver = null;

            // Act
            TestDelegate action = () => WebDriverUtilities.WebDriverToObject(webDriver);

            // Assert  
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void ObjectToWebDriver_NullWebDriverObj_ThrowsArgumentException()
        {
            // Arrange
            object webDriverObj = null;

            // Act
            TestDelegate action = () => WebDriverUtilities.ObjectToWebDriver(webDriverObj);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        public void WebDriverToJavaScriptExecutor_NullWebDriver_ThrowsArgumentNullException()
        {
            // Arrange
            IWebDriver webDriver = null;

            // Act
            TestDelegate action = () => WebDriverUtilities.WebDriverToJavaScriptExecutor(webDriver);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
