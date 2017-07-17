using System;
using WbTstr.Configuration.WebDrivers;
using WbTstr.Configuration.WebDrivers.Exceptions;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.Fixtures.Attributes;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Recorders.Interfaces;
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
        private Lazy<IWebDriverConfig> _webDriverConfigPointer;

        protected WbTstrFixture()
        {
            _tracker = new T().Initialize();
            _performer = new P().Initialize(WebDriverConfig, _tracker);

            I = new R().Initialize(_performer) as R;
        } 

        /* Properties -------------------------------------------------------*/

        protected Lazy<IWebDriverConfig> WebDriverConfig
        {
            get
            {
                if (_webDriverConfigPointer == null)
                {
                    if (_webDriverConfig == null)
                    {
                        var attribute = Attribute.GetCustomAttribute(GetType(), typeof(WebDriverConfigAttribute)) as WebDriverConfigAttribute;
                        if (attribute != null)
                        {
                            _webDriverConfig = string.IsNullOrEmpty(attribute.Preset)
                                ? WebDriverConfigs.GetDefault(attribute.Type)
                                : WebDriverConfigs.GetFromPreset(attribute.Type, attribute.Preset);
                        }
                    }

                    // As long as _webDriverConfig is initialized at the moment we need it, it's all fine.
                    _webDriverConfigPointer = new Lazy<IWebDriverConfig>(() => 
                    {
                        if (_webDriverConfig == null)
                        {
                            throw new MissingWebDriverConfigException();
                        }

                        return _webDriverConfig;
                    });
                }

                return _webDriverConfigPointer;
            }
        }

        protected R I { get; }

        /* Methods ----------------------------------------------------------*/

        protected void Use(IWebDriverConfig webDriverConfig)
        {
            if (_webDriverConfig != null)
            {
                throw new InvalidOperationException("Cannot override already initialized WebDriver configuration.");
            }

            _webDriverConfig = webDriverConfig ?? throw new ArgumentNullException(nameof(webDriverConfig));
        }

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
