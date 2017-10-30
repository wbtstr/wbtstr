using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WbTstr.Configuration.WebDrivers;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.UnitTests._Auxiliaries;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.UnitTests.Configuration.WebDrivers
{
    [TestFixture]
    public class WebDriverConfigsTests
    {
        [TestCase]
        public void GetDefault_NoArgument_ReturnsNotNull()
        {
            // Arrange

            // Act
            var config = WebDriverConfigs.GetDefault();

            // Assert
            Assert.NotNull(config);
        }

        [TestCase]
        public void GetDefault_StringType_ReturnsNotNull()
        {
            // Arrange
            string type = "Chrome";

            // Act
            var config = WebDriverConfigs.GetDefault(type);

            // Assert
            Assert.NotNull("Chrome");
        }

        [TestCase]
        public void GetDefault_NullType_ThrowsArgumentNullException()
        {
            // Arrange
            string type = null;

            // Act
            TestDelegate action = () => WebDriverConfigs.GetDefault(type);

            // Assert
            Assert.Throws<ArgumentNullException>(action); 
        }

        [TestCase]
        public void GetDefault_EmptyType_ThrowsArgumentException()
        {
            // Arrange

            // Act
            TestDelegate[] actions =
            {
                () => WebDriverConfigs.GetDefault(""),
                () => WebDriverConfigs.GetDefault("   ")
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }

        [TestCase]
        public void GetDefault_InvalidType_ThrowsArgumentException()
        {
            // Arrange
            string type = "not_a_valid_type";

            // Act
            TestDelegate action = () => WebDriverConfigs.GetDefault(type);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [TestCase]
        public void GetDefault_EnumDefaultType_ThrowsArgumentException()
        {
            // Arrange
            WebDriverType type = default(WebDriverType);

            // Act
            TestDelegate action = () => WebDriverConfigs.GetDefault(type);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [TestCase]
        public void GetDefault_NonDefaultEnumTypes_DoesNotThrow()
        {
            // Arrange
            var webDriverTypes = Enum.GetValues(typeof(WebDriverType)).Cast<WebDriverType>();

            // Act
            var actions = new List<TestDelegate>();
            foreach (var webDriverType in webDriverTypes)
            {
                if (webDriverType == default(WebDriverType))
                {
                    continue;
                }

                actions.Add(() => WebDriverConfigs.GetDefault(webDriverType));                
            }

            // Assert
            AssertMultiple.DoesNotThrow(actions);
        }

        [TestCase]
        public void GetDefault_NonDefaultEnumTypes_ReturnRightConfigType()
        {
            // Arrange 
            var webDriverTypes = Enum.GetValues(typeof(WebDriverType)).Cast<WebDriverType>();

            // Act
            var webDriverConfigs = new Dictionary<WebDriverType, IWebDriverConfig>();
            foreach (var webDriverType in webDriverTypes)
            {
                if (webDriverType == default(WebDriverType))
                {
                    continue;
                }

                webDriverConfigs[webDriverType] = WebDriverConfigs.GetDefault(webDriverType);
            }

            // Assert
            foreach (var webDriverConfig in webDriverConfigs)
            {
                Assert.AreEqual(webDriverConfig.Value.Type, webDriverConfig.Key);
            }
        }

        [TestCase]
        public void GetFromPreset_NullPreset_ThrowsArgumentNullException()
        {
            // Arrange
            string preset = null;

            // Act
            TestDelegate action = () => WebDriverConfigs.GetFromPreset(WebDriverType.Chrome, preset);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void GetFromPreset_EnumDefaultType_ThrowsArgumentNullException()
        {
            // Arrange
            WebDriverType type = default(WebDriverType);
            string preset = null;

            // Act
            TestDelegate action = () => WebDriverConfigs.GetFromPreset(type, preset);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [TestCase]
        public void GetFromPreset_EmptyPreset_ThrowsArgumentException()
        {
            // Arrange

            // Act
            TestDelegate[] actions =
            {
                () => WebDriverConfigs.GetFromPreset(WebDriverType.Chrome, ""),
                () => WebDriverConfigs.GetFromPreset(WebDriverType.Chrome, "   ")
            };

            // Assert
            AssertMultiple.Throws<ArgumentException>(actions);
        }
    }
}
