using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using WbTstr.UnitTests._Auxiliaries;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.UnitTests.WebDrivers.Exceptions
{
    [TestFixture]
    public class UnexpectedWebDriverStateTests
    {
        private const string DefaultMessage = "I'm an exception!";
        private UnexpectedWebDriverStateException _defaultException;

        [SetUp]
        public void SetUp()
        {
            _defaultException = new UnexpectedWebDriverStateException(DefaultMessage);
        }

        [TestCase]
        public void Constructor_NullMessage_ThrowsArgumentNullException()
        {
            // Arrange
            string message = null;

            // Act
            TestDelegate action = () => new UnexpectedWebDriverStateException(message);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Constructor_EmptyMessage_DoesNotThrow()
        {
            // Arrange

            // Act
            TestDelegate[] actions =
            {
                () => new UnexpectedWebDriverStateException(""),
                () => new UnexpectedWebDriverStateException("   "),
            };

            // Assert
            AssertMultiple.DoesNotThrow(actions);
        }

        [TestCase]
        public void Message_GetMessageProperty_ReturnsConstructorMessage()
        {
            // Arrange

            // Act
            string message = _defaultException.Message;

            // Asset
            Assert.AreEqual(DefaultMessage, message);
        }
    }
}
