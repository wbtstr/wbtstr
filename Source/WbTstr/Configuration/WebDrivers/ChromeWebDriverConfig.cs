using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.Configuration.WebDrivers
{
    public class ChromeWebDriverConfig : IWebDriverConfig
    {
        public ChromeWebDriverConfig()
        {
            Capabilities = new Dictionary<string, string>();
            Arguments = new Dictionary<string, string>();
            Extensions = new Dictionary<string, bool>();
        }

        public ChromeWebDriverConfig(IDictionary<string, string> capabilities, IDictionary<string, string> arguments, IDictionary<string, bool> extensions, WebDriverProxyConfig proxy)
        {
            Capabilities = capabilities ?? new Dictionary<string, string>();
            Arguments = arguments ?? new Dictionary<string, string>();
            Extensions = extensions ?? new Dictionary<string, bool>();
            Proxy = proxy;
        }

        /*-------------------------------------------------------------------*/

        public WebDriverType Type { get; } = WebDriverType.Chrome;

        public WebDriverProxyConfig Proxy { get; set; }

        public IDictionary<string, string> Capabilities { get; }

        public IDictionary<string, string> Arguments { get; }

        public IDictionary<string, bool> Extensions { get; }

        internal ChromeOptions AsChromeOptions()
        {
            var options = new ChromeOptions();
            foreach (var argument in Arguments)
            {
                options.AddArgument(argument.Key);
            }

            foreach (var extension in Extensions)
            {
                if (extension.Value)
                {
                    options.AddEncodedExtension(extension.Key);                    
                }
                else
                {
                    options.AddExtension(extension.Key);
                }
            }

            foreach (var capability in Capabilities)
            {
                options.AddAdditionalCapability(capability.Key, capability.Value);
            }

            return options;
        }
    }
}
