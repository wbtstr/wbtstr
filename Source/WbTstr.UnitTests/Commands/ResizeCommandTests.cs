using System;
using System.Drawing;
using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using WbTstr.Commands;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class ResizeCommandTests
    {
        private const int DefaultWidth = 500;
        private const int DefaultHeight = 500;

        private ResizeCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new ResizeCommand(DefaultWidth, DefaultHeight);
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
        public void Constructor_InvalidWidthHeight_ThrowsArgumentException()
        {
            // Arrange
            int invalid = -1;
            int valid = 0;

            // Act
            TestDelegate[] actions =
            {
                () => new ResizeCommand(invalid, valid),
                () => new ResizeCommand(valid, invalid),
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }

        [TestCase]
        public void Execute_NoArgs_SetSize()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var options = Substitute.For<IOptions>();
            var window = Substitute.For<IWindow>();

            webDriver.Manage().Returns(options);
            options.Window.Returns(window);

            // Act
            _defaultCommand.Execute(webDriver);

            // Assert
            window.Received().Size = new Size(DefaultWidth, DefaultHeight);
        }
    }
}
