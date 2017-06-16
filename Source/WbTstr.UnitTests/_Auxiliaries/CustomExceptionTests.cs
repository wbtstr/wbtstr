using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WbTstr.Configuration.WebDrivers.Exceptions;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.UnitTests._Auxiliaries
{
    public class CustomExceptionTests<T> where T : Exception, new()
    {
        private const string DefaultMessage = "I'm an exception!";
        private T _defaultException;

        [SetUp]
        public void SetUp()
        {
            _defaultException = (T)Activator.CreateInstance(typeof(T), new object[] { DefaultMessage });
        }

        [TestCase]
        public void Constructor_NullMessage_ThrowsArgumentNullException()
        {
            // Arrange
            string message = null;

            // Act
            TestDelegate action = () =>
            {
                try
                {
                    var e = (T) Activator.CreateInstance(typeof(T), new object[] {message});
                }
                catch (TargetInvocationException ex)
                {
                    // So we can assert to the actual exception
                    if (ex.InnerException != null)
                    {
                        throw ex.InnerException;
                    }
                }
            };

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
                () => { var e = (T) Activator.CreateInstance(typeof(T), new object[] {""}); },
                () => { var e = (T) Activator.CreateInstance(typeof(T), new object[] {" "}); },
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
