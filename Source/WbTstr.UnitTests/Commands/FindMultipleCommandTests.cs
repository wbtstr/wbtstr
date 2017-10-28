using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WbTstr.Commands;
using WbTstr.Proxies;
using WbTstr.UnitTests._Auxiliaries;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class FindMultipleCommandTests
    {
        private const string DefaultSelector = "a";

        private FindMultipleCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new FindMultipleCommand(DefaultSelector);
        }

        [TestCase]
        public void Constructor_SelectorNull_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            TestDelegate action = () => new FindMultipleCommand(null);

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
            var webElements = new List<IWebElement> { webElement };

            webDriver.FindElements(null).ReturnsForAnyArgs(webElements.AsReadOnly());

            // Act
            var elements = _defaultCommand.Execute(webDriver);

            // Assert
            Assert.AreSame(webElement, (elements.First() as ElementProxy)?.InnerWebElement);
        }

        [TestCase]
        public void Execute_NonExistingElement_ThrowsElementNotFoundException()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();

            webDriver.FindElements(null).ReturnsForAnyArgs(x => throw new NoSuchElementException());

            // Act
            TestDelegate action = () => _defaultCommand.Execute(webDriver);

            // Assert
            Assert.Throws<ElementNotFoundException>(action);
        }
    }
}
