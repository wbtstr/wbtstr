using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using WbTstr.Fixtures.Attributes;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.UnitTests.Fixtures.Attributes
{
    [TestFixture]
    public class WebDriverConfigAttributeTests
    {
        private const WebDriverType DefaultWebDriverType = WebDriverType.Chrome;
        private const WebDriverScope DefaultWebDriverScope = WebDriverScope.Fixture;
        private const string DefaultWebDriverPreset = "Default";

        private WebDriverConfigAttribute _defaultAttribute;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _defaultAttribute = new WebDriverConfigAttribute(DefaultWebDriverType, DefaultWebDriverScope, DefaultWebDriverPreset);
        }

        [TestCase]
        public void Constructor_EnumDefaultType_ThrowsArgumentException()
        {
            // Arrange
            WebDriverType type = default(WebDriverType);

            // Act
            TestDelegate action = () => new WebDriverConfigAttribute(type);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [TestCase]
        public void Properties_GetProperties_ReturnConstructorValues()
        {
            // Arrange

            // Act
            var type = _defaultAttribute.Type;
            var preset = _defaultAttribute.Preset;

            // Assert
            Assert.AreEqual(WebDriverType.Chrome, type);
            Assert.AreEqual(DefaultWebDriverPreset, preset);
        }
    }
}
