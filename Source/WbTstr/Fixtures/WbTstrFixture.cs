using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Configuration.WebDrivers;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.Fixtures.Attributes;
using WbTstr.Session.Runners.Interfaces;
using WbTstr.Session.Trackers.Interfaces;

namespace WbTstr.Fixtures
{
    public abstract class WbTstrFixture<R, T> 
        where R: ISessionRunner, new()
        where T: ISessionTracker, new()
    {
        private readonly ISessionRunner _runner;
        private readonly ISessionTracker _tracker;
        private IWebDriverConfig _webDriverConfig;


        protected WbTstrFixture()
        {
            _runner = new R().Initialize(WebDriverConfig);
            _tracker = new T().Initialize();
        } 

        /* Properties -------------------------------------------------------*/

        protected IWebDriverConfig WebDriverConfig
        {
            get
            {
                if (_webDriverConfig == null)
                {
                    var attribute = Attribute.GetCustomAttribute(GetType(), typeof(WebDriverConfigAttribute)) as WebDriverConfigAttribute;
                    _webDriverConfig = attribute != null ? WebDriverConfigs.GetFromConfig(attribute.Name) : WebDriverConfigs.GetDefault();
                }

                return _webDriverConfig;
            }
        }

        /* Methods ----------------------------------------------------------*/

        protected void Retry(Action expression, int times = 3, int delay = 15)
        {
            throw new NotImplementedException();
        }

        protected void WaitUntilTrue(Func<bool> expression)
        {
            throw new NotImplementedException();
        }

        protected void WaitUntilFalse(Func<bool> expression)
        {
            throw new NotImplementedException();
        }
    }
}
