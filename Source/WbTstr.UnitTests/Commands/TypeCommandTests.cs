using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework.Internal;
using NUnit.Framework;
using OpenQA.Selenium;
using WbTstr.Commands;
using WbTstr.Proxies.Interfaces;
using WbTstr.UnitTests._Auxiliaries;
using WbTstr.WebDrivers.Extensions;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class TypeCommandTests
    {
        private const string DefaultText = "typing!";
        private const string DefaultSelector = "#input";
        private const bool DefaultClear = false;

        private TypeCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new TypeCommand(DefaultText, DefaultSelector, DefaultClear);
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

        [TestCase]
        public void Constructor_NullText_ThrowsArgumentNullException()
        {
            // Arrange
            string text = null;

            // Act
            TestDelegate action = () => new TypeCommand(text, DefaultSelector, DefaultClear);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Constructor_NullSelector_ThrowsArgumentNullException()
        {
            // Arrange
            string selector = null;

            // Act
            TestDelegate action = () => new TypeCommand(DefaultText, selector, DefaultClear);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Constructor_NullElement_ThrowsArgumentNullException()
        {
            // Arrange
            IElement element = null;

            // Act
            TestDelegate action = () => new TypeCommand(DefaultText, element, DefaultClear);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Execute_NoClearRequested_ClearNotCalled()
        {
            // Arrange
            var command = new TypeCommand(DefaultText, DefaultSelector, false);
            var webDriver = Substitute.For<IWebDriver>();
            var webElement = Substitute.For<IWebElement>();

            webDriver.FindElementBySelector(DefaultSelector).Returns(webElement);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            webElement.DidNotReceive().Clear();
        }

        [TestCase]
        public void Execute_ClearRequested_ClearCalled()
        {
            // Arrange
            var command = new TypeCommand(DefaultText, DefaultSelector, true);
            var webDriver = Substitute.For<IWebDriver>();
            var webElement = Substitute.For<IWebElement>();

            webDriver.FindElementBySelector(DefaultSelector).Returns(webElement);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            webElement.Received().Clear();
        }

        [TestCase]
        public void Execute_NoArgs_CallsSendKeys()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var webElement = Substitute.For<IWebElement>();

            webDriver.FindElementBySelector(DefaultSelector).Returns(webElement);

            // Act
            IgnoreExceptions.Run(() => _defaultCommand.Execute(webDriver));

            // Assert
            webElement.Received().SendKeys(DefaultText);
        }
    }
}
