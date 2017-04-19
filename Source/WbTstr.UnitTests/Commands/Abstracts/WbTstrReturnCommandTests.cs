using NUnit.Framework;
using System;
using WbTstr.UnitTests._Stubs;

namespace WbTstr.UnitTests.Commands.Abstracts
{
    [TestFixture]
    public class WbTstrReturnCommandTests
    {
        private ReturnCommandStub _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new ReturnCommandStub();
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
