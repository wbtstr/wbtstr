using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.Configuration.WebDrivers
{
    public class ChromeWebDriverConfig : IWebDriverConfig
    {
        public WebDriverType Type { get; } = WebDriverType.Chrome;
    }
}
