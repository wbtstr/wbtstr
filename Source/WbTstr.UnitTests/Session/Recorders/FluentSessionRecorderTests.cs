using System;
using NSubstitute;
using NUnit.Framework.Internal;
using NUnit.Framework;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Recorders;

namespace WbTstr.UnitTests.Session.Recorders
{
    [TestFixture]
    public class FluentSessionRecorderTests
    {
        private FluentSessionRecorder _defaultRecorder;

        [SetUp]
        public void SetUp()
        {
            _defaultRecorder = new FluentSessionRecorder();
        }

        /*-------------------------------------------------------------------*/

        [TestCase]
        public void Initialize_NullPerformer_ThrowsArgumentNullException()
        {
            // Arrange 
            ISessionPerformer performer = null;

            // Act
            TestDelegate action = () => _defaultRecorder.Initialize(performer);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Initialize_CalledTwice_ThrowsInvalidOperationException()
        {
            ISessionPerformer performer = Substitute.For<ISessionPerformer>();

            // Act
            _defaultRecorder.Initialize(performer);
            TestDelegate action = () => _defaultRecorder.Initialize(performer);

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}
