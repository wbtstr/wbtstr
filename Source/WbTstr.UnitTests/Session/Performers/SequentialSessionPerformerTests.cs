using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework.Internal;
using NUnit.Framework;
using WbTstr.Commands.Interfaces;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.Session.Performers;
using WbTstr.Session.Trackers.Interfaces;

namespace WbTstr.UnitTests.Session.Performers
{
    [TestFixture]
    public class SequentialSessionPerformerTests
    {
        private SequentialSessionPerformer _defaultPerformer;

        [SetUp]
        public void SetUp()
        {
            _defaultPerformer = new SequentialSessionPerformer();
        }

        /*-------------------------------------------------------------------*/

        [TestCase]
        public void Initialize_NullWebDriverConfig_ThrowsArgumentNullException()
        {
            // Arrange
            Lazy<IWebDriverConfig> webDriverConfig = null;
            var tracker = Substitute.For<ISessionTracker>();

            // Act
            TestDelegate action = () => _defaultPerformer.Initialize(webDriverConfig, tracker);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Initialize_NullSessionTracker_ThrowsArgumentNullExpection()
        {
            // Arrange
            var webDriverConfig = Substitute.For<Lazy<IWebDriverConfig>>();
            ISessionTracker tracker = null;

            // Act
            TestDelegate action = () => _defaultPerformer.Initialize(webDriverConfig, tracker);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Initialize_CalledTwice_ThrowsInvalidOperationException()
        {
            // Arrange
            var webDriverConfig = Substitute.For<Lazy<IWebDriverConfig>>();
            var tracker = Substitute.For<ISessionTracker>();

            // Act
            var performer = _defaultPerformer.Initialize(webDriverConfig, tracker);
            TestDelegate action = () => performer.Initialize(webDriverConfig, tracker);

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [TestCase]
        public void Perform_NullActionCommand_ThrowsArgumentNullException()
        {
            // Arrange
            IActionCommand command = null;

            // Act
            TestDelegate action = () => _defaultPerformer.Perform(command);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void PerformAndReturn_NullActionCommand_ThrowsArgumentNullException()
        {
            // Arrange
            IReturnCommand<object> command = null;

            // Act
            TestDelegate action = () => _defaultPerformer.PerformAndReturn(command);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
