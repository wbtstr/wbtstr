using NUnit.Framework;
using System;
using WbTstr.Commands;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class AuthenticateCommandTests
    {
        // #GuessTheCms
        public const string DefaultUsername = "admin";
        public const string DefaultPassword = "b";

        private AuthenticateCommand _defaultCommand;

        [SetUp]
        public void OneTimeSetUp()
        {
            _defaultCommand = new AuthenticateCommand(DefaultUsername, DefaultPassword, TimeSpan.FromSeconds(1));
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
        public void Constructor_NullUsername_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            TestDelegate action = () => new AuthenticateCommand(null, DefaultPassword, TimeSpan.FromSeconds(1));

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Constructor_NullPassword_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            TestDelegate action = () => new AuthenticateCommand(DefaultUsername, null, TimeSpan.FromDays(1));

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Constructor_ValidArguments_DoesNotThrow()
        {
            // Arrange

            // Act

            // Assert
        }

    }
}
