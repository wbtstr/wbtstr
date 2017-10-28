using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using WbTstr.Commands;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;
using WbTstr.UnitTests._Auxiliaries;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class FindCommandTests
    {
        private const string DefaultSelector = "body";

        private FindCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new FindCommand(DefaultSelector);
        }

        [TestCase]
        public void Constructor_SelectorNull_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            TestDelegate action = () => new FindCommand(null);

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
        public void Execute_ExistingElement_ReturnElement()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var webElement = Substitute.For<IWebElement>();

            webDriver.FindElement(null).ReturnsForAnyArgs(webElement);

            // Act
            IElement element = _defaultCommand.Execute(webDriver);

            // Assert
            Assert.AreSame(webElement, (element as ElementProxy)?.InnerWebElement);
        }

        [TestCase]
        public void Execute_NonExistingElement_ThrowsElementNotFoundException()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();

            webDriver.FindElement(null).ReturnsForAnyArgs(x => throw new NoSuchElementException());

            // Act
            TestDelegate action = () => _defaultCommand.Execute(webDriver);

            // Assert
            Assert.Throws<ElementNotFoundException>(action);
        }
    }
}
