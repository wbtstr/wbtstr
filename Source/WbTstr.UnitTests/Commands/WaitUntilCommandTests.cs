using System;
using NUnit.Framework;
using WbTstr.Commands;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class WaitUntilCommandTests
    {
        private readonly TimeSpan DefaultInterval = new TimeSpan(0, 0, 0, 0, 1);
        private readonly TimeSpan DefaultTimeout = new TimeSpan(0, 0, 0, 0, 10);

        private WaitUntilCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new WaitUntilCommand(() => true, DefaultInterval, DefaultTimeout);
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
