using System;
using System.Linq;
using System.Collections.Generic;
using WbTstr.Commands;
using WbTstr.Configuration.WebDrivers;
using WbTstr.Configuration.WebDrivers.Exceptions;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.Fixtures.Attributes;
using WbTstr.Proxies.Interfaces;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Recorders.Interfaces;
using WbTstr.Session.Trackers.Interfaces;
using WbTstr.WebDrivers.Interfaces;
using System.Diagnostics;
using WbTstr.WebDrivers.Constants;
using WbTstr.Utilities.Extensions;

namespace WbTstr.Fixtures
{
    public abstract class WbTstrFixture<R, P, T> : IDisposable
        where R: class, ISessionRecorder, new()
        where P: class, ISessionPerformer, new()
        where T: class, ISessionTracker, new()
    {
        private readonly IWebDriverConfig _webDriverConfig;
        private readonly WebDriverScope _webDriverScope;
        private readonly IDictionary<string, R> _recorders = new Dictionary<string, R>();
        private readonly IDictionary<string, P> _performers = new Dictionary<string, P>();
        private readonly IDictionary<string, T> _trackers = new Dictionary<string, T>();

        protected WbTstrFixture()
        {
            if (Attribute.GetCustomAttribute(GetType(), typeof(WebDriverConfigAttribute)) is WebDriverConfigAttribute attribute)
            {
                _webDriverScope = attribute.Scope;

                bool usePreset = !string.IsNullOrEmpty(attribute.Preset);
                _webDriverConfig = usePreset ? WebDriverConfigs.GetFromPreset(attribute.Type, attribute.Preset)
                                             : WebDriverConfigs.GetDefault(attribute.Type);
            }
            else
            {
                throw new MissingWebDriverConfigException("WebDriverConfig attribute is not present.");
            }
        } 

        /* Properties -------------------------------------------------------*/

        protected R I
        {
            get
            {
                var scopeName = "fixture";
                if (_webDriverScope == WebDriverScope.Test)
                {
                    scopeName = new StackFrame(1).GetMethod().Name;
                }

                // Check if scoped recorder already exists.
                if (_recorders.TryGetValue(scopeName, out R recorder))
                {
                    return recorder;
                }

                // Get rid of any previous recorders.
                _recorders.RemoveAll();

                var tracker = GetScopedTracker(scopeName);
                var performer = GetScopedPerformer(scopeName, tracker);
                return (_recorders[scopeName] = new R().Initialize(performer) as R);
            }
        }

        /* Methods ----------------------------------------------------------*/

        private T GetScopedTracker(string scopeName)
        {
            // Check if scoped tracker already exists.
            if (_trackers.TryGetValue(scopeName, out T tracker))
            {
                return tracker;
            }

            // Get rid of any previous trackers.
            _trackers.RemoveAll();

            return (_trackers[scopeName] = new T().Initialize() as T);
        }

        private P GetScopedPerformer(string scopeName, T tracker)
        {
            // Check if scoped performer already exists.
            if (_performers.TryGetValue(scopeName, out P performer))
            {
                return performer;
            }

            // Get rid of any previous performers.
            _performers.DisposeAndRemoveAll();

            return (_performers[scopeName] = new P().Initialize(_webDriverConfig, tracker) as P);
        }

        protected IPage CapturePage()
        {
            var scopeName = "fixture";
            if (_webDriverScope == WebDriverScope.Test)
            {
                scopeName = new StackFrame(1).GetMethod().Name;
            }

            var performer = GetScopedPerformer(scopeName, null);

            var command = new CapturePageCommand();
            return performer.PerformAndReturn(command);
        }

        protected void SetFixtureCookies(IEnumerable<ICookie> cookies)
        {
            if (cookies == null) throw new ArgumentNullException(nameof(cookies));

            cookies.ToList().ForEach(SetFixtureCookie);
        }

        protected void SetFixtureCookie(ICookie cookie)
        {
            if (cookie == null) throw new ArgumentNullException(nameof(cookie));

            // TODO
        }

        /* Finalizer --------------------------------------------------------*/

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            _performers.Values.ToList().ForEach(p => p?.Dispose());
        }
    }
}
