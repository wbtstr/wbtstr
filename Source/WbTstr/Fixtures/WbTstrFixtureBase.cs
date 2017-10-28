using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WbTstr.Configuration.WebDrivers;
using WbTstr.Configuration.WebDrivers.Exceptions;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.Fixtures.Attributes;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Recorders.Interfaces;
using WbTstr.Session.Trackers.Interfaces;
using WbTstr.Utilities.Extensions;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.Fixtures
{
    public abstract class WbTstrFixtureBase<R, P, T> : IDisposable
        where R : class, ISessionRecorder, new()
        where P : class, ISessionPerformer, new()
        where T : class, ISessionTracker, new()
    {
        private readonly IDictionary<string, R> _recorders = new Dictionary<string, R>();
        private readonly IDictionary<string, P> _performers = new Dictionary<string, P>();
        private readonly IDictionary<string, T> _trackers = new Dictionary<string, T>();
        private readonly IWebDriverConfig _webDriverConfig;
        private readonly WebDriverScope _webDriverScope;

        protected WbTstrFixtureBase()
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

        /*-------------------------------------------------------------------*/

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
                if (_recorders.TryGetValue(scopeName, out R scopedRecorder))
                {
                    return scopedRecorder;
                }

                // Get rid of any previous recorders.
                _recorders.Clear();

                var tracker = GetScopedTracker(scopeName);
                var performer = GetScopedPerformer(scopeName, tracker);
                var recorder = new R().Initialize(performer) as R;

                return (_recorders[scopeName] = recorder);
            }
        }

        private T GetScopedTracker(string scopeName)
        {
            // Check if scoped tracker already exists.
            if (_trackers.TryGetValue(scopeName, out T scopedTracker))
            {
                return scopedTracker;
            }

            // Get rid of any previous trackers.
            _trackers.Clear();

            var tracker = new T().Initialize() as T;
            return (_trackers[scopeName] = tracker);
        }

        private P GetScopedPerformer(string scopeName, T tracker)
        {
            // Check if scoped performer already exists.
            if (_performers.TryGetValue(scopeName, out P scopedPerformer))
            {
                return scopedPerformer;
            }

            // Get rid of any previous performers.
            _performers.DisposeAndClear();

            var performer = new P().Initialize(_webDriverConfig, tracker) as P;
            return (_performers[scopeName] = performer);
        }

        /*-------------------------------------------------------------------*/

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
