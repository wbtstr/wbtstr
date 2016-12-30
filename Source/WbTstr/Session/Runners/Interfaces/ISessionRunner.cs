using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Configuration.WebDrivers.Interfaces;

namespace WbTstr.Session.Runners.Interfaces
{
    public interface ISessionRunner
    {
        ISessionRunner Initialize(IWebDriverConfig webDriverConfig);
    }
}
