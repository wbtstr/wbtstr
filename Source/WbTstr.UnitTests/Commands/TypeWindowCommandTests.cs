using System;
using NUnit.Framework;
using WbTstr.Commands;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class TypeWindowCommandTests
    {
        private const string DefaultText = "typing!";

        private TypeWindowCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new TypeWindowCommand(DefaultText);
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
            TestDelegate action = () => new TypeWindowCommand(text);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Constructor_InvalidText_ThrowsArgumentException()
        {
            // Arrange
            string text = "";

            // Act
            TestDelegate action = () => new TypeWindowCommand(text);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
