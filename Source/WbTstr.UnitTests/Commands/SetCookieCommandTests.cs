using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands;
using WbTstr.Proxies.Interfaces;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class SetCookieCommandTests
    {
        private SetCookieCommand _defaultCommand;

        [SetUp]
        public void OneTimeSetUp()
        {
            var cookie = Substitute.For<ICookie>();
            _defaultCommand = new SetCookieCommand(cookie);
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

        [TestCase]
        public void Constructor_CookieNull_ThrowArgumentNullException()
        {
            // Arrange

            // Act
            TestDelegate action = () => new SetCookieCommand(null);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
