using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.UnitTests._Stubs
{
    public class NoneWebDriverConfigStub : IWebDriverConfig
    {
        WebDriverType IWebDriverConfig.Type => WebDriverType.None;
    }
}
