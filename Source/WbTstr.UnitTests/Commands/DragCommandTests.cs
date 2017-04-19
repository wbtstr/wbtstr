using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using WbTstr.Commands;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class DragCommandTests
    {
        private const string DefaultSelector = "body";
        private DragCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new DragCommand(DefaultSelector, DefaultSelector);
        }

        public void Constructor_NullSelector_ThrowsArgumentNullException()
        {
            // Arrange
            string selector = null;

            // Act
            TestDelegate[] actions = {
                () => new DragCommand(selector, selector),
                () => new DragCommand(selector, DefaultSelector),
                () => new DragCommand(DefaultSelector, selector),
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }

        [TestCase]
        public void Constructor_NullElement_ThrowArgumentNullException()
        {
            // Arrange
            IElement elementA = null;
            IElement elementB = null;
            IElement elementC = Substitute.For<IElement>();

            // Act
            TestDelegate[] actions = {
                () => new DragCommand(elementA, elementB),
                () => new DragCommand(elementC, elementB),
                () => new DragCommand(elementA, elementC),
            };

            // Assert
            AssertMultiple.Throws<ArgumentNullException>(actions);
        }

        [TestCase]
        public void Constructor_NullSelectorOffset_ThrowsArgumentNullException()
        {
            // Arrange
            string selector = null;

            // Act
            TestDelegate[] actions = {
                () => new DragCommand(selector, 0, 0),
                () => new DragCommand(0, 0, selector),
            };

            // Assert
            AssertMultiple.Throws<ArgumentNullException>(actions);
        }

        [TestCase]
        public void Constructor_NullElementOffset_ThrowsArgumentNullException()
        {
            // Arrange
            IElement element = null;

            // Act
            TestDelegate[] actions = {
                () => new DragCommand(element, 0, 0),
                () => new DragCommand(0, 0, element),
            };

            // Assert
            AssertMultiple.Throws<ArgumentNullException>(actions);
        }

        [TestCase]
        public void Constructor_InvalidSelector_ThrowsArgumentException()
        {
            // Arrange
            string selector = DefaultSelector;
            string empty = "";
            string whitespace = " ";

            // Act
            TestDelegate[] actions = {
                () => new DragCommand(selector, empty),
                () => new DragCommand(selector, whitespace),
                () => new DragCommand(empty, selector),
                () => new DragCommand(whitespace, selector),
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }

        [TestCase]
        public void Constructor_InvalidOffsetSelector_ThrowsArgumentException()
        {
            // Arrange
            string selector = DefaultSelector;

            // Act
            TestDelegate[] actions = {
                () => new DragCommand(selector, -1, 0),
                () => new DragCommand(selector, 0, -1),
                () => new DragCommand(selector, -1, -1),
                () => new DragCommand(-1, 0, selector),
                () => new DragCommand(0, -1, selector),
                () => new DragCommand(-1, -1, selector),
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }

        [TestCase]
        public void Constructor_InvalidOffsetElement_ThrowsArgumentException()
        {
            // Arrange
            IElement element = Substitute.For<IElement>();

            // Act
            TestDelegate[] actions = {
                () => new DragCommand(element, -1, 0),
                () => new DragCommand(element, 0, -1),
                () => new DragCommand(element, -1, -1),
                () => new DragCommand(-1, 0, element),
                () => new DragCommand(0, -1, element),
                () => new DragCommand(-1, -1, element),
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }

        [TestCase]
        public void Constructor_ValidInput_DoesNotThrow()
        {
            // Arrange
            string selector = DefaultSelector;
            IElement element = Substitute.For<IElement>();

            // Act
            TestDelegate[] actions =
            {
                () => new DragCommand(selector, selector),
                () => new DragCommand(element, element),
                () => new DragCommand(selector, 0, 0),
                () => new DragCommand(element, 0, 0),
                () => new DragCommand(0, 0, selector),
                () => new DragCommand(0, 0, element),
                () => new DragCommand(0, 0, 0, 0),
            };

            // Assert
            AssertMultiple.DoesNotThrow(actions);
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
        public void Execute_TwoSelectors_PerformDragElementToElement()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var webElementA = Substitute.For<IWebElement>();
            var webElementB = Substitute.For<IWebElement>();
            var command = Substitute.ForPartsOf<DragCommand>("A", "B");

            webDriver.FindElement(By.CssSelector("A")).Returns(webElementA);
            webDriver.FindElement(By.CssSelector("B")).Returns(webElementB);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.Received().PerformDragElementToElement(webDriver, webElementA, webElementB);
        }

        [TestCase]
        public void Execute_TwoElements_PerformDragElementToElement()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var webElementA = Substitute.For<IWebElement>();
            var webElementB = Substitute.For<IWebElement>();
            var elementA = new Element(webElementA);
            var elementB = new Element(webElementB);
            var command = Substitute.ForPartsOf<DragCommand>(elementA, elementB);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.Received().PerformDragElementToElement(webDriver, webElementA, webElementB);
        }

        [TestCase]
        public void Execute_SelectorOffset_PerformDragElementToElement()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var webElement = Substitute.For<IWebElement>();
            var command = Substitute.ForPartsOf<DragCommand>("A", 0, 0);

            webDriver.FindElement(By.CssSelector("A")).Returns(webElement);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.Received().PerformDragElementToCoordinate(webDriver, webElement, 0, 0);
        }

        [TestCase]
        public void Execute_ElementOffset_PerformDragElementToElement()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var webElement = Substitute.For<IWebElement>();
            var element = new Element(webElement);
            var command = Substitute.ForPartsOf<DragCommand>(element, 0, 0);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.Received().PerformDragElementToCoordinate(webDriver, webElement, 0, 0);
        }

        [TestCase]
        public void Execute_OffsetSelector_PerformDragElementToElement()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var webElement = Substitute.For<IWebElement>();
            var command = Substitute.ForPartsOf<DragCommand>(0, 0, "B");

            webDriver.FindElement(By.CssSelector("B")).Returns(webElement);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.Received().PerformDragCoordinateToElement(webDriver, 0, 0, webElement);
        }

        [TestCase]
        public void Execute_OffsetElement_PerformDragElementToElement()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var webElement = Substitute.For<IWebElement>();
            var element = new Element(webElement);
            var command = Substitute.ForPartsOf<DragCommand>(0, 0, element);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.Received().PerformDragCoordinateToElement(webDriver, 0, 0, webElement);
        }
    }
}
