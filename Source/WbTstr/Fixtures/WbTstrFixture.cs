using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Configuration.WebDrivers;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.Fixtures.Attributes;
using WbTstr.Session.Recorders.Interfaces;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Trackers.Interfaces;

namespace WbTstr.Fixtures
{
    public abstract class WbTstrFixture<R, P, T> : IDisposable
        where R: class, ISessionRecorder, new()
        where P: class, ISessionPerformer, new()
        where T: class, ISessionTracker, new()
    {
        private readonly ISessionPerformer _performer;
        private readonly ISessionTracker _tracker;
        private IWebDriverConfig _webDriverConfig;

        protected WbTstrFixture()
        {
            _tracker = new T().Initialize();
            _performer = new P().Initialize(WebDriverConfig, _tracker);

            I = new R().Initialize(_performer) as R;
        } 

        /* Properties -------------------------------------------------------*/

        protected IWebDriverConfig WebDriverConfig
        {
            get
            {
                if (_webDriverConfig == null)
                {
                    var attribute = Attribute.GetCustomAttribute(GetType(), typeof(WebDriverConfigAttribute)) as WebDriverConfigAttribute;
                    if (attribute == null)
                    {
                        _webDriverConfig = WebDriverConfigs.GetDefault();
                    }
                    else
                    {
                        _webDriverConfig = string.IsNullOrEmpty(attribute.Preset) 
                            ? WebDriverConfigs.GetDefaultForType(attribute.Type) 
                            : WebDriverConfigs.GetFromPreset(attribute.Type, attribute.Preset);
                    }
                }

                return _webDriverConfig;
            }
        }

        protected R I { get; }

        /* Finalizer --------------------------------------------------------*/

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || _performer == null) return;

            _performer.Dispose();
        }
    }
}
