using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using WbTstr.Commands;
using WbTstr.Proxies.Interfaces;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class ExecuteJsCommandTests
    {
        private const string DefaultJsExpression = "return (1 + 1)";

        private ExecuteJsCommand<long> _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new ExecuteJsCommand<long>(DefaultJsExpression, async: false);
        }

        [TestCase]
        public void Constructor_NullJsExpression_ThrowsNullException()
        {
            // Arrange

            // Act
            TestDelegate action = () => new ExecuteJsCommand<string>(null);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Constructor_InvalidJsExpression_ThrowsArgumentException()
        {
            // Arrange

            // Act
            TestDelegate[] actions = 
            {
                () => new ExecuteJsCommand<string>(""),
                () => new ExecuteJsCommand<string>(" "),
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }

        [TestCase]
        public void Constructor_InvalidReturnType_ThrowsArgumentException()
        {
            // Arrange

            // Act
            TestDelegate[] actions =
            {
                () => new ExecuteJsCommand<int>(DefaultJsExpression),
                () => new ExecuteJsCommand<short>(DefaultJsExpression),
                () => new ExecuteJsCommand<object>(DefaultJsExpression),
                () => new ExecuteJsCommand<IWebElement>(DefaultJsExpression),
                () => new ExecuteJsCommand<IEnumerable>(DefaultJsExpression),
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }

        [TestCase]
        public void Constructor_ValidReturnType_DoesNotThrow()
        {
            // Arrange

            // Act
            TestDelegate[] actions =
            {
                () => new ExecuteJsCommand<string>(DefaultJsExpression),
                () => new ExecuteJsCommand<bool>(DefaultJsExpression),
                () => new ExecuteJsCommand<long>(DefaultJsExpression),
                () => new ExecuteJsCommand<IElement>(DefaultJsExpression),
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
        public void Execute_ReturnPrimitiveSync_PerformJsSyncAndReturnPrimitive()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = Substitute.ForPartsOf<ExecuteJsCommand<long>>(DefaultJsExpression, false);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.ReceivedWithAnyArgs().PerformJsSyncAndReturnPrimitive(null, null);
        }

        [TestCase]
        public void Execute_ReturnPrimitiveAsync_PerformJsAsyncAndReturnPrimitive()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = Substitute.ForPartsOf<ExecuteJsCommand<long>>(DefaultJsExpression, true);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.ReceivedWithAnyArgs().PerformJsAsyncAndReturnPrimitive(null, null);
        }

        [TestCase]
        public void Execute_ReturnElementSync_PerformJsSyncAndReturnElement()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = Substitute.ForPartsOf<ExecuteJsCommand<IElement>>(DefaultJsExpression, false);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.ReceivedWithAnyArgs().PerformJsSyncAndReturnElement(null, null);
        }

        [TestCase]
        public void Execute_ReturnElementAsync_PerformJsAsyncAndReturnElement()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = Substitute.ForPartsOf<ExecuteJsCommand<IElement>>(DefaultJsExpression, true);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            command.ReceivedWithAnyArgs().PerformJsAsyncAndReturnElement(null, null);
        }
    }
}
