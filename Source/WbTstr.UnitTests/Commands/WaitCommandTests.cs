using System;
using NUnit.Framework;
using WbTstr.Commands;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class WaitCommandTests
    {
        private readonly TimeSpan DefaultDuration = new TimeSpan(0, 0, 0, 0, 0);

        private WaitCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new WaitCommand(DefaultDuration);
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
                () => new WaitCommand(new TimeSpan(0, 0, invalid, invalid, invalid)), 
                () => new WaitCommand(new TimeSpan(0, 0, invalid, valid, valid)),
                () => new WaitCommand(new TimeSpan(0, 0, valid, invalid, valid)),
                () => new WaitCommand(new TimeSpan(0, 0, valid, valid, invalid)),
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }
    }
}
