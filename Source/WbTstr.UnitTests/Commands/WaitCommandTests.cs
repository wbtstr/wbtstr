using System;
using NUnit.Framework;
using WbTstr.Commands;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class WaitCommandTests
    {
        private const int DefaultMilliseconds = 0;
        private const int DefaultSeconds = 0;
        private const int DefaultMinutes = 0;

        private WaitCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new WaitCommand(DefaultMilliseconds, DefaultSeconds, DefaultMinutes);
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
        public void Constructor_InvalidParams_ThrowsArgumentException()
        {
            // Arrange 
            int valid = 0;
            int invalid = -1;

            // Act
            TestDelegate[] actions =
            {
                () => new WaitCommand(invalid, invalid, invalid), 
                () => new WaitCommand(invalid, valid, valid),
                () => new WaitCommand(valid, invalid, valid),
                () => new WaitCommand(valid, valid, invalid),
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }
    }
}
