using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands;
using WbTstr.Proxies.Interfaces;
using WbTstr.Utilities.Constants;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class ClickCommandTests
    {
        private const string DefaultSelector = "body";
        private const MouseClick DefaultMouseClick = MouseClick.Single;

        private ClickCommand _defaultCommand;

        [SetUp]
        public void OneTimeSetUp()
        {
            _defaultCommand = new ClickCommand(DefaultSelector, DefaultMouseClick);
        }

        [TestCase(null, MouseClick.None)]
        [TestCase(null, MouseClick.Single)]
        public void Constructor_InvalidInput_ThrowsArgumentNullException(string selector, MouseClick mouseClick)
        {
            // Arrange

            // Act
            TestDelegate action = () => new ClickCommand(selector, mouseClick);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase("", MouseClick.Single)]
        [TestCase(" ", MouseClick.Single)]
        [TestCase(DefaultSelector, MouseClick.None)]
        public void Constructor_InvalidInput_ThrowsArgumentException(string selector, MouseClick mouseClick)
        {
            // Arrange

            // Act
            TestDelegate action = () => new ClickCommand(selector, mouseClick);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [TestCase(DefaultSelector, MouseClick.Single)]
        [TestCase(DefaultSelector, MouseClick.Double)]
        [TestCase(DefaultSelector, MouseClick.Context)]
        public void Constructor_ValidInputSelector_DoesNotThrow(string selector, MouseClick mouseClick)
        {
            // Arrange

            // Act
            TestDelegate action = () => new ClickCommand(selector, mouseClick);

            // Assert
            Assert.DoesNotThrow(action);
        }

        [TestCase(MouseClick.Single)]
        [TestCase(MouseClick.Double)]
        [TestCase(MouseClick.Context)]
        public void Constructor_ValidInputElement_DoesNotThrow(MouseClick mouseClick)
        {
            // Arrange
            var element = Substitute.For<IElement>();

            // Act
            TestDelegate action = () => new ClickCommand(element, mouseClick);

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
