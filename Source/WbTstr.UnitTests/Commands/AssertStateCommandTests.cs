using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using WbTstr.Commands;
using WbTstr.UnitTests._Auxiliaries;
using WbTstr.WebDrivers.Constants;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class AssertStateCommandTests
    {
        private const PropertyKey DefaultPropertyKey = PropertyKey.Title;
        private const string DefaultPropertyValue = "WbTstr 4 Life";

        private AssertStateCommand _defaultCommand;

        [SetUp]
        public void OneTimeSetUp()
        {
            _defaultCommand = new AssertStateCommand(DefaultPropertyKey, DefaultPropertyValue);
        }

        [TestCase]
        public void Constructor_UninitializedPropertyKey_ThrowsArgumentException()
        {
            // Arrange
            PropertyKey propertyKey = default(PropertyKey);

            // Act
            TestDelegate action = () => new AssertStateCommand(propertyKey, DefaultPropertyValue);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [TestCase]
        public void Constructor_UninitializedPropertyValue_ThrowsArgumentNullException()
        {
            // Arrange
            string propertyValue = null;

            // Act
            TestDelegate action = () => new AssertStateCommand(DefaultPropertyKey, propertyValue);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Constructor_EmptyPropertyValue_DoesNotThrow()
        {
            // Arrange
            string propertyValue = string.Empty;

            // Act
            TestDelegate action = () => new AssertStateCommand(DefaultPropertyKey, propertyValue);

            // Assert
            Assert.DoesNotThrow(action);
        }

        [TestCase]
        public void Constructor_TypicalPropertyKeyValue_DoesNotThrow()
        {
            // Arrange

            // Act
            TestDelegate action = () => new AssertStateCommand(DefaultPropertyKey, DefaultPropertyValue);

            // Assert
            Assert.DoesNotThrow(action);
        }

        [TestCase]
        public void Execute_AssertTitlePropertyValid_UseRightStateProperty()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = new AssertStateCommand(PropertyKey.Title, DefaultPropertyValue);

            webDriver.Title.Returns(DefaultPropertyValue);

            // Act
            TestDelegate action = () => command.Execute(webDriver);

            // Assert
            Assert.DoesNotThrow(action);
            string title = webDriver.Received().Title;
        }

        [TestCase]
        public void Execute_AssertTitlePropertyWrong_ThrowsUnexpectedWebDriverStateException()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = new AssertStateCommand(PropertyKey.Title, DefaultPropertyValue);

            webDriver.Title.Returns(DefaultPropertyValue + "!");

            // Act
            TestDelegate action = () => command.Execute(webDriver);

            // Assert
            Assert.Throws<UnexpectedWebDriverState>(action);
            string title = webDriver.Received().Title;
        }

        [TestCase]
        public void Execute_AssertUrlPropertyValid_UseRightStateProperty()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = new AssertStateCommand(PropertyKey.Url, DefaultPropertyValue);

            webDriver.Url.Returns(DefaultPropertyValue);

            // Act
            TestDelegate action = () => command.Execute(webDriver);

            // Assert
            Assert.DoesNotThrow(action);
            string url = webDriver.Received().Url;
        }

        [TestCase]
        public void Execute_AssertUrlPropertyWrong_ThrowsUnexpectedWebDirverStateException()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = new AssertStateCommand(PropertyKey.Url, DefaultPropertyValue);

            webDriver.Url.Returns(DefaultPropertyValue + "!");

            // Act
            TestDelegate action = () => command.Execute(webDriver);

            // Assert
            Assert.Throws<UnexpectedWebDriverState>(action);
            string url = webDriver.Received().Url;
        }

        [TestCase]
        public void ToString_NoArguments_ReturnString()
        {
            // Arrange

            // Act
            string stringRepresentation = _defaultCommand.ToString();

            // Assert
            AssertString.NotNullOrWhiteSpace(stringRepresentation);
        }
    }
}
