using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using UriParser = WbTstr.Utilities.UriParser;

namespace WbTstr.UnitTests.Utilities
{
    [TestFixture]
    public class UriParserTests
    {
        public void ParseWebUrl_NullUrl_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            TestDelegate action = () => UriParser.ParseWebUrl(null);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
