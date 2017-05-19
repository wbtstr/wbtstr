using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using WbTstr.Commands;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    public class NavigateCommandTests
    {
        private const string DefaultUrl = "http://www.wbtstr.net";

        private NavigateCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new NavigateCommand(DefaultUrl);
        }

        [TestCase]
        public void Constructor_NullUrl_ThrowsArgumentNullException()
        {
            // Arrange
            string url = null;

            // Act
            TestDelegate action = () => new NavigateCommand(url);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Constructor_InvalidUrl_ThrowsArgumentException()
        {
            // Arrange

            // Act
            TestDelegate[] actions =
            {
                () => new NavigateCommand(""),
                () => new NavigateCommand(" "),
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }

        [TestCase]
        public void Constructor_InvalidUrl_ThrowsUriFormatException()
        {
            // Arrange

            // Act
            TestDelegate[] actions =
            {
                () => new NavigateCommand("wb tstr"),
                () => new NavigateCommand("<('-'<)"),
            };

            // Assert
            AssertMultiple.Throws<UriFormatException>(actions);
        }

        [TestCase]
        public void Constructor_ValidUrl_DoesNotThrow()
        {
            // Arrange

            // Act
            TestDelegate[] actions =
            {
                () => new NavigateCommand("http://www.wbtstr.net"),
                () => new NavigateCommand("http://wbtstr.net"),
                () => new NavigateCommand("www.wbtstr.net"),
                () => new NavigateCommand("wbtstr.net"),
            };

            // Assert
            AssertMultiple.DoesNotThrow(actions);
        }

        [TestCase]
        public void Constructor_ValidUri_DoesNotThrow()
        {
            // Arrange
            Uri uri = new Uri(DefaultUrl);

            // Act
            TestDelegate action = () => new NavigateCommand(uri);

            // Assert
            Assert.DoesNotThrow(action);
        }

        [TestCase]
        public void Execute_NoArgs_NavigateToUri()
        {
            // Arrange
            Uri uri = new Uri(DefaultUrl);
            var webDriver = Substitute.For<IWebDriver>();
            var navigation = Substitute.For<INavigation>();

            webDriver.Navigate().Returns(navigation);

            // Act
            IgnoreExceptions.Run(() => _defaultCommand.Execute(webDriver));

            // Assert
            navigation.Received().GoToUrl(uri);
        }
    }
}
