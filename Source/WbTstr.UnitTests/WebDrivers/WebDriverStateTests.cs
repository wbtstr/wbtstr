using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework.Internal;
using NUnit.Framework;
using OpenQA.Selenium;
using WbTstr.WebDrivers;

namespace WbTstr.UnitTests.WebDrivers
{
    [TestFixture]
    public class WebDriverStateTests
    {
        [TestCase]
        public void Constructor_NullWebDriver_ThrowsArgumentNullException()
        {
            // Arrange
            IWebDriver webDriver = null;

            // Act
            TestDelegate action = () => new WebDriverState(webDriver);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void UrlProperty_CallOnWebDriverState_AccessOnWebDriver()
        {
            // Arrange
            IWebDriver webDriver = Substitute.For<IWebDriver>();
            WebDriverState webDriverState = new WebDriverState(webDriver);

            // Act
            string url1 = webDriverState.Url;

            // Assert
            string url2 = webDriver.Received().Url;
        }

        [TestCase]
        public void TitleProperty_CallOnWebDriverState_AccessOnWebDriver()
        {
            // Arrange
            IWebDriver webDriver = Substitute.For<IWebDriver>();
            WebDriverState webDriverState = new WebDriverState(webDriver);

            // Act
            string title1 = webDriverState.Title;

            // Assert
            string title2 = webDriver.Received().Title;
        }
    }
}
