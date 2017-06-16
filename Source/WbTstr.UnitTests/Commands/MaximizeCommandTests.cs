using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using WbTstr.Commands;
using WbTstr.Proxies;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class MaximizeCommandTests
    {
        private MaximizeCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new MaximizeCommand();
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
        public void Execute_NoArgs_PerformWindowMaximize()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var options = Substitute.For<IOptions>();
            var window = Substitute.For<IWindow>();

            webDriver.Manage().Returns(options);
            options.Window.Returns(window);

            // Act
            IgnoreExceptions.Run(() => _defaultCommand.Execute(webDriver));

            // Assert
            window.Received().Maximize();
        }

    }
}
