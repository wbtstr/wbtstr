using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using WbTstr.Commands;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class AssertStateExpCommandTests
    {
        private const string DefaultPropertyValue = "WbTstr 4 Life";

        private AssertStateExpCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new AssertStateExpCommand(x => x.Title == DefaultPropertyValue);
        }

        [TestCase]
        public void Constructor_TypicalPropertyKeyValue_DoesNotThrow()
        {
            // Arrange

            // Act
            TestDelegate action = () => new AssertStateExpCommand(x => x.Title == DefaultPropertyValue);

            // Assert
            Assert.DoesNotThrow(action);
        }

        [TestCase]
        public void Constructor_UninitializedPropertyValue_DoesNotThrow()
        {
            // Arrange
            string propertyValue = null;

            // Act
            TestDelegate action = () => new AssertStateExpCommand(x => x.Title == propertyValue);

            // Assert
            Assert.DoesNotThrow(action);
        }

        [TestCase]
        public void Constructor_EmptyPropertyValue_DoesNotThrow()
        {
            // Arrange
            string propertyValue = string.Empty;

            // Act
            TestDelegate action = () => new AssertStateExpCommand(x => x.Title == propertyValue);

            // Assert
            Assert.DoesNotThrow(action);
        }

        [TestCase]
        public void Execute_AssertTitleProperty_UseRightStateProperty()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();

            // Act
            IgnoreExceptions.Run(() => _defaultCommand.Execute(webDriver));

            // Assert
            string title = webDriver.Received().Title;
        }

        [TestCase]
        public void Execute_AssertUrlProperty_UseRightStateProperty()
        {
            // Arrange
            var webDriver = Substitute.For<IWebDriver>();
            var command = new AssertStateExpCommand(x => x.Url == DefaultPropertyValue);

            // Act
            IgnoreExceptions.Run(() => command.Execute(webDriver));

            // Assert
            string url = webDriver.Received().Url;
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
    }
}
