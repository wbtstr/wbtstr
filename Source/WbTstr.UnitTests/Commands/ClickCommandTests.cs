using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using WbTstr.Commands;
using WbTstr.Proxies.Interfaces;
using WbTstr.UnitTests._Auxiliaries;
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
        public void Execute_ClickOnSelector_FindSingleElement()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();

            // Act
            IgnoreExceptions.Run(() => _defaultCommand.Execute(webDriver));

            // Assert
            var element = webDriver.Received().FindElement(By.CssSelector(DefaultSelector));
        }

        [TestCase]
        public void Execute_MouseClickSingle_PerformSingleClick()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = Substitute.ForPartsOf<ClickCommand>(DefaultSelector, MouseClick.Single);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.ReceivedWithAnyArgs().PerformSingleClickOnElement(webDriver, null);
        }

        [TestCase]
        public void Execute_MouseClickDouble_PerformDoubleClick()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = Substitute.ForPartsOf<ClickCommand>(DefaultSelector, MouseClick.Double);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.ReceivedWithAnyArgs().PerformDoubleClickOnElement(webDriver, null);
        }

        [TestCase]
        public void Execute_MouseClickContext_PerformContextClick()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = Substitute.ForPartsOf<ClickCommand>(DefaultSelector, MouseClick.Context);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.ReceivedWithAnyArgs().PerformContextClickOnElement(Arg.Any<object>(), Arg.Any<oj);
        }
    }
}
