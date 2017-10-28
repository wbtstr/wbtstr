using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Configuration.WebDrivers;
using WbTstr.Configuration.WebDrivers.Exceptions;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.IntegrationTests.Configuration.WebDriver
{
    [TestFixture]
    public class WebDriverConfigsTests
    {
        [TestCase]
        public void GetFromPreset_FilledPreset_NotNull()
        {
            // Arrange
            WebDriverType type = WebDriverType.Chrome;
            string preset = "chrome";

            // Act
            var actual = WebDriverConfigs.GetFromPreset(type, preset) as ChromeWebDriverConfig;

            //Assert
            Assert.NotNull(actual);
        }

        [TestCase]
        public void GetFromPreset_FilledWrongPresetName_ThrowsException()
        {
            // Arrange
            WebDriverType type = WebDriverType.Chrome;
            string preset = "wrongPreset";

            // Act
            TestDelegate action = () => WebDriverConfigs.GetFromPreset(type, preset);

            // Assert
            Assert.Throws<MissingWebDriverConfigSectionException>(action);
        }
    }
}
