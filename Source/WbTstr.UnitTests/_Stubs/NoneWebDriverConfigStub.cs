using System.Collections.Generic;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.UnitTests._Stubs
{
    public class NoneWebDriverConfigStub : IWebDriverConfig
    {
        WebDriverType IWebDriverConfig.Type => WebDriverType.None;

        public IDictionary<string, string> Capabilities => new Dictionary<string, string>();

        public IDictionary<string, string> Arguments => new Dictionary<string, string>();
    }
}
