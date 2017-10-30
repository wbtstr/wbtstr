using NUnit.Framework;
using System;
using WbTstr.Utilities;

namespace WbTstr.UnitTests.Utilities
{
    [TestFixture]
    public class XmlParserTests
    {
        [TestCase]
        public void XmlNodeToProxyConfig_NullInput_ThrowsArgumentNulLException()
        {
            // Arrange

            // Act
            var config = XmlParser.XmlNodeToProxyConfig(null);

            // Assert
            Assert.IsNull(config);
        }
    }
}
