using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands.Interfaces;
using WbTstr.Session.Trackers.Interfaces;

namespace WbTstr.Session.Trackers
{
    public class SimpleSessionTracker : ISessionTracker
    {
        public ISessionTracker Initialize()
        {
            return this;
        }

        public void MarkExecutionBegin(IActionCommand actionCommand)
        {
            Console.WriteLine($"Begin: {actionCommand}");
        }

        public void MarkExecutionBegin<T>(IReturnCommand<T> returnCommand)
        {
            Console.WriteLine($"Begin: {returnCommand}");
        }

        public void MarkExecutionEnd(IActionCommand actionCommand)
        {
            Console.WriteLine($"End: {actionCommand}");
        }

        public void MarkExecutionEnd<T>(IReturnCommand<T> returnCommand)
        {
            Console.WriteLine($"End: {returnCommand}");
        }
    }
}
