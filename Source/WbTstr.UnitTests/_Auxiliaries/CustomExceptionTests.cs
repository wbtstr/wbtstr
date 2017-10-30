using System;
using System.Reflection;
using NUnit.Framework;

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
        public void Constructor_Parameterless_DoesNotThrow()
        {
            // Arrange

            // Act
            TestDelegate action = () => Activator.CreateInstance(typeof(T));

            // Assert
            Assert.DoesNotThrow(action);
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
