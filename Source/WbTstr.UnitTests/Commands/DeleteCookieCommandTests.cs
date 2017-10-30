using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands;
using WbTstr.UnitTests._Auxiliaries;

namespace WbTstr.UnitTests.Commands
{
    [TestFixture]
    public class DeleteCookieCommandTests
    {
        private const string DefaultName = "login";

        private DeleteCookieCommand _defaultCommand;

        [SetUp]
        public void OneTimeSetUp()
        {
            _defaultCommand = new DeleteCookieCommand(DefaultName);
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
        public void Constructor_NameNull_ThrowArgumentNullException()
        {
            // Arrange

            // Act
            TestDelegate action = () => new DeleteCookieCommand(null);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
