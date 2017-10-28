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
    }
}
