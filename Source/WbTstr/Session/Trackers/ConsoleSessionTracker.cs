using System;
using WbTstr.Commands.Interfaces;
using WbTstr.Session.Trackers.Interfaces;

namespace WbTstr.Session.Trackers
{
    public class ConsoleSessionTracker : ISessionTracker
    {
        public ISessionTracker Initialize()
        {
            return this;
        }

        public void MarkExecutionBegin(IActionCommand actionCommand)
        {
            if (actionCommand == null) throw new ArgumentNullException(nameof(actionCommand));

            Console.WriteLine($"Begin: {actionCommand}");
        }

        public void MarkExecutionBegin<T>(IReturnCommand<T> returnCommand)
        {
            if (returnCommand == null) throw new ArgumentNullException(nameof(returnCommand));

            Console.WriteLine($"Begin: {returnCommand}");
        }

        public void MarkExecutionEnd(IActionCommand actionCommand)
        {
            if (actionCommand == null) throw new ArgumentNullException(nameof(actionCommand));

            Console.WriteLine($"End: {actionCommand}");
        }

        public void MarkExecutionEnd<T>(IReturnCommand<T> returnCommand)
        {
            if (returnCommand == null) throw new ArgumentNullException(nameof(returnCommand));

            Console.WriteLine($"End: {returnCommand}");
        }
    }
}
