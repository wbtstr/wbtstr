using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.Configuration.WebDrivers
{
    public static class WebDriverConfigs
    {
        internal static IWebDriverConfig GetDefault()
        {
            return GetDefault(WebDriverType.Chrome);
        }

        public static IWebDriverConfig GetDefault(string type)
        {
            var webDriverType = (WebDriverType)Enum.Parse(typeof(WebDriverType), type, true);
            return GetDefault(webDriverType);
        }

        public static IWebDriverConfig GetDefault(WebDriverType type)
        {
            if (type == default(WebDriverType)) throw new ArgumentException(nameof(type));

            IWebDriverConfig webDriverConfig = null;
            switch (type)
            {
                case WebDriverType.Chrome:
                    webDriverConfig = GetDefaultChromeWebDriverConfig();
                    break;
            }

            return webDriverConfig;
        }

        public static IWebDriverConfig GetFromPreset(WebDriverType type, string preset)
        {
            if (type == default(WebDriverType)) throw new ArgumentException(nameof(type));
            if (preset == null) throw new ArgumentNullException(nameof(preset));

            IWebDriverConfig webDriverConfig = null;
            switch (type)
            {
                case WebDriverType.Chrome:
                    webDriverConfig = GetPresetChromeWebDriverConfig(preset);
                    break;
            }

            return webDriverConfig;
        }

        private static ChromeWebDriverConfig GetDefaultChromeWebDriverConfig()
        {
            return new ChromeWebDriverConfig();
        }

        private static ChromeWebDriverConfig GetPresetChromeWebDriverConfig(string preset)
        {
            throw new NotImplementedException();
        }
    }
}
