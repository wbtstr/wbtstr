using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.Configuration.WebDrivers
{
    public class ChromeWebDriverConfig : IWebDriverConfig
    {
        public WebDriverName Type { get; } = WebDriverName.Chrome;
    }
}
