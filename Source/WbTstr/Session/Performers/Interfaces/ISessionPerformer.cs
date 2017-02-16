using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands.Interfaces;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.Session.Trackers.Interfaces;

namespace WbTstr.Session.Performers.Interfaces
{
    public interface ISessionPerformer : IDisposable
    {
        ISessionPerformer Initialize(IWebDriverConfig webDriverConfig, ISessionTracker tracker);

        bool DirectPlay { get; set; }

        void Perform(IActionCommand actionCommand);

        T PerformAndReturn<T>(IReturnCommand<T> command);

        void Play();
    }
}
