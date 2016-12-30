using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.Session.Runners.Interfaces;

namespace WbTstr.Session.Runners
{
    public class SequentialSessionRunner : ISessionRunner
    {
        public ISessionRunner Initialize(IWebDriverConfig webDriverConfig)
        {
            throw new NotImplementedException();
        }
    }
}
