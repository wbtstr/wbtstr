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

        void MarkExecutionBegin(IActionCommand actionCommand);

        void MarkExecutionBegin<T>(IReturnCommand<T> command);

        void MarkExecutionEnd(IActionCommand actionCommand);

        void MarkExecutionEnd<T>(IReturnCommand<T> command);
    }
}
