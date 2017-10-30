using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
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
        public void WebDriverToObject_WebDriverInstance_ReturnsAsObject()
        {
            // Arrange 
            IWebDriver webDriver = Substitute.For<IWebDriver>();

            // Act
            object instance = WebDriverUtilities.WebDriverToObject(webDriver);

            // Assert
            Assert.IsInstanceOf<object>(instance);
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
