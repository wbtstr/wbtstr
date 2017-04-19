using NSubstitute;
using NUnit.Framework;
using System;
using WbTstr.Commands;
using WbTstr.Proxies.Interfaces;
using WbTstr.UnitTests._Auxiliaries;

// Constructor  string  string      no throw
// Constructor  element element     no throw
// Constructor  string  0,0         no throw
// Constructor  element 0,0         no throw
// Constructor  0,0     string      no throw
// Constructor  0,0     element     no throw
// Constructor  0,0     0,0         no throw

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
            string selectorA = null;
            string selectorB = null;
            string selectorC = DefaultSelector;

            // Act
            TestDelegate[] actions = {
                () => new DragCommand(selectorA, selectorB),
                () => new DragCommand(selectorC, selectorB),
                () => new DragCommand(selectorA, selectorC),
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
    }
}
