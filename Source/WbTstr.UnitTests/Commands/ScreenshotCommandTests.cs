using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using WbTstr.Commands;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class ScreenshotCommandTests
    {
        private const string DefaultFileName = "screenshot.png";
        private const string DefaultDirectoryPath = "%TEMP%";

        private ScreenshotCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new ScreenshotCommand(DefaultFileName, DefaultDirectoryPath);
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
        public void Constructor_NullFileName_ThrowsArgumentNullException()
        {
            // Arrange
            string fileName = null;

            // Act 
            TestDelegate action = () => new ScreenshotCommand(fileName, DefaultDirectoryPath);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Constructor_NullDirectoryPath_ThrowsArgumentNullException()
        {
            // Arrange
            string directoryPath = null;

            // Act
            TestDelegate action = () => new ScreenshotCommand(DefaultFileName, directoryPath);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Constructor_InvalidFileName_ThrowsArgumentException()
        {
            // Arrange

            // Act
            TestDelegate[] actions =
            {
                () => new ScreenshotCommand("", DefaultDirectoryPath),
                () => new ScreenshotCommand("   ", DefaultDirectoryPath),
                () => new ScreenshotCommand("filename.*", DefaultDirectoryPath),
                () => new ScreenshotCommand("filename<?>", DefaultDirectoryPath), 
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }

        [TestCase]
        public void Constructor_InvalidDirectoryPath_ThrowsArgumentException()
        {
            // Arrange

            // Act
            TestDelegate[] actions =
            {
                () => new ScreenshotCommand(DefaultFileName, ""), 
                () => new ScreenshotCommand(DefaultFileName, "   "), 
                () => new ScreenshotCommand(DefaultFileName, "path.*"),
                () => new ScreenshotCommand(DefaultFileName, "path<?>"),
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }

        [TestCase("file.jpg", ScreenshotImageFormat.Jpeg)]
        [TestCase("file.png", ScreenshotImageFormat.Png)]
        public void Execute_NoArgs_CallSaveAsFile(string filename, ScreenshotImageFormat imageFormat)
        {
            // Arrange
            var command = new ScreenshotCommand(filename, DefaultDirectoryPath);
            var webDriver = Substitute.For<IWebDriver, ITakesScreenshot>(); 
            var screenshot = Substitute.For<Screenshot>(Convert.ToBase64String(Encoding.UTF8.GetBytes("fake")));

            webDriver.TakeScreenshot().Returns(screenshot);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            IgnoreExceptions.Run<ArgumentException>(() =>
            {
                screenshot.Received().SaveAsFile(filename, imageFormat);
            });
        }
    }
}
