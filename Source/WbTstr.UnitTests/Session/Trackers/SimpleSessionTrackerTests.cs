using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using WbTstr.Commands.Interfaces;
using WbTstr.Session.Trackers;

namespace WbTstr.UnitTests.Session.Trackers
{
    [TestFixture]
    public class SimpleSessionTrackerTests
    {
        private SimpleSessionTracker _defaultTracker;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _defaultTracker = new SimpleSessionTracker();
        }

        [TestCase]
        public void MarkExecutionBegin_NullActionCommand_ThrowsArgumentNullException()
        {
            // Arrange
            IActionCommand command = null;

            // Act
            TestDelegate action = () => _defaultTracker.MarkExecutionBegin(command);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void MarkExecutionEnd_NullActionCommand_ThrowsArgumentNullException()
        {
            // Arrange
            IActionCommand command = null;

            // Act
            TestDelegate action = () => _defaultTracker.MarkExecutionEnd(command);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void MarkExecutionBegin_NullReturnCommand_ThrowsArgumentNullException()
        {
            // Arrange
            IReturnCommand<object> command = null;

            // Act
            TestDelegate action = () => _defaultTracker.MarkExecutionBegin(command);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void MarkExecutionEnd_NullReturnCommand_ThrowsArgumentNullException()
        {
            // Arrange
            IReturnCommand<object> command = null;

            // Act
            TestDelegate action = () => _defaultTracker.MarkExecutionEnd(command);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

    }
}
