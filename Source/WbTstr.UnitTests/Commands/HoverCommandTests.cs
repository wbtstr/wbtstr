using System;
using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using WbTstr.Commands;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;
using WbTstr.UnitTests._Auxiliaries;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class HoverCommandTests
    {
        private const string DefaultSelector = "body";

        private HoverCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new HoverCommand(DefaultSelector);
        }

        [TestCase]
        public void Constructor_SelectorNull_ThrowsArgumentNullException()
        {
            // Arrange
            string selector = null;

            // Act
            TestDelegate action = () => new HoverCommand(selector);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Constructor_ElementNull_ThrowsArgumentNullException()
        {
            // Arrange
            IElement selector = null;

            // Act
            TestDelegate action = () => new HoverCommand(selector);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void ToString_NoArgs_ReturnsString()
        {
            // Arrange

            // Act
            string stringRepresentation = _defaultCommand.ToString();

            // Assert
            AssertString.NotNullOrEmpty(stringRepresentation);
        }

        [TestCase]
        public void Execute_Selector_FindSingleElement()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();

            // Act
            IgnoreExceptions.Run(() => _defaultCommand.Execute(webDriver));

            // Assert
            webDriver.ReceivedWithAnyArgs().FindElement(null);
        }

        [TestCase]
        public void Execute_NonExistingElement_ThrowsElementNotFoundException()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();

            webDriver.FindElement(null).ReturnsForAnyArgs(w => throw new NoSuchElementException());

            // Act
            TestDelegate action = () => _defaultCommand.Execute(webDriver);

            // Assert
            Assert.Throws<ElementNotFoundException>(action);
        }

        [TestCase]
        public void Execute_ExistingElement_PerformMoveMouseToElement()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var webElement = Substitute.For<IWebElement>();
            var element = new ElementProxy(webElement);
            var command = Substitute.ForPartsOf<HoverCommand>(element);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.Received().PerformMoveMouseToElement(webDriver, webElement);
        }
    }
}
