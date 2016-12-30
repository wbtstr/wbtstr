using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Configuration.WebDrivers.Interfaces;

namespace WbTstr.Configuration.WebDrivers
{
    public static class WebDriverConfigs
    {
        public static IWebDriverConfig GetDefault()
        {
            return new ChromeWebDriverConfig();
        }

        public static IWebDriverConfig GetFromConfig(string name)
        {
            return GetDefault();
        }
    }
}
