using NUnit.Framework;
using System;
using WbTstr.Commands;
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
        public void Execute_UninitializedWebDriver_ThrowsArgumentNullException()
        {
            // Arrange
            object webDriverObj = null;

            // Act
            TestDelegate action = () => _defaultCommand.Execute(webDriverObj);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Execute_DifferentThanWebDriverType_ThrowsArgumentException()
        {
            // Arrange
            object webDriverObj = "Not a WebDriver object";

            // Act
            TestDelegate action = () => _defaultCommand.Execute(webDriverObj);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
