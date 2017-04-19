using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands.Abstracts;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands.Abstracts
{
    [TestFixture]
    public class WbTstrReturnCommandTests
    {
        private DummyReturnCommand _defaultCommand;

        [SetUp]
        public void SetUp()
        {
            _defaultCommand = new DummyReturnCommand();
        }

        [TestCase]
        public void Execute_UninitializedWebDriver_ThrowsArgumentNullException()
        {
            // Arrange
            object webDriverObj = null;

            // Act
            TestDelegate action = () => _defaultCommand.Execute(webDriverObj);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Execute_DifferentThanWebDriverType_ThrowsArgumentException()
        {
            // Arrange
            object webDriverObj = "Not a WebDriver object";

            // Act
            TestDelegate action = () => _defaultCommand.Execute(webDriverObj);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
