﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WbTstr.UnitTests._Auxiliaries;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.UnitTests.WebDrivers.Exceptions
{
    [TestFixture]
    public class ElementNotFoundExceptionTests
    {
        private const string DefaultMessage = "I'm an exception!";
        private ElementNotFoundException _defaultException;

        [SetUp]
        public void SetUp()
        {
            _defaultException = new ElementNotFoundException(DefaultMessage);
        }

        [TestCase]
        public void Constructor_NullMessage_ThrowsArgumentNullException()
        {
            // Arrange
            string message = null;

            // Act
            TestDelegate action = () => new ElementNotFoundException(message);

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
                () => new ElementNotFoundException(""),
                () => new ElementNotFoundException("   "),
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
