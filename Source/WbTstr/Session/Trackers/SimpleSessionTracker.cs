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

        public void MarkExecutionBegin(ICommand command)
        {
            Console.WriteLine($"Begin: {command}");
        }

        public void MarkExecutionEnd(ICommand command)
        {
            Console.WriteLine($"End: {command}");
        }
    }
}
