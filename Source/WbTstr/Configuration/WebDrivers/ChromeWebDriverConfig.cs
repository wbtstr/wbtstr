using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Configuration.WebDrivers.Constants;
using WbTstr.Configuration.WebDrivers.Interfaces;

namespace WbTstr.Configuration.WebDrivers
{
    public class ChromeWebDriverConfig : IWebDriverConfig
    {
        public WebDriverType Type { get; } = WebDriverType.Chrome;
    }
}
