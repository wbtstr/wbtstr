using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.Commands;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Recorders.Interfaces;
using WbTstr.Session.Trackers.Interfaces;

namespace WbTstr.Session.Recorders
{
    public class SimpleSessionRecorder : ISessionRecorder
    {
        private bool _initialized;
        private ISessionPerformer _performer;

        public ISessionRecorder Initialize(ISessionPerformer performer)
        {
            if (_initialized)
            {
                throw new InvalidOperationException($"{nameof(SimpleSessionRecorder)} can be initialized only once.");
            }

            _performer = performer;

            _initialized = true;
            return this;
        }

        /* Methods ----------------------------------------------------------*/

        public SimpleSessionRecorder NavigateTo(string url)
        {
            var command = new NavigateCommand(url);
            _performer.Perform(command);

            return this;
        }
    }
}
