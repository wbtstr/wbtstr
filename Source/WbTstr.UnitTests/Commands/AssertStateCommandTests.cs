using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using WbTstr.Commands;
using WbTstr.UnitTests._Auxiliaries;
using WbTstr.WebDrivers.Constants;

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
        public void Execute_AssertTitleProperty_UseRightStateProperty()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = new AssertStateCommand(PropertyKey.Title, DefaultPropertyValue);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            string title = webDriver.Received().Title;
        }

        [TestCase]
        public void Execute_AssertUrlProperty_UseRightStateProperty()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = new AssertStateCommand(PropertyKey.Url, DefaultPropertyValue);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            string url = webDriver.Received().Url;
        }
    }
}
