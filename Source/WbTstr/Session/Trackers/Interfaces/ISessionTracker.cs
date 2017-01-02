using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Session.Trackers.Interfaces
{
    public interface ISessionTracker
    {
        ISessionTracker Initialize();

        void MarkExecutionBegin(ICommand command);

        void MarkExecutionEnd(ICommand command);
    }
}
