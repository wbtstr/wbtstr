using System;
using System.Threading;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    public class WaitCommand : IActionCommand
    {
        private readonly int _milliseconds;
        private readonly int _minutes;
        private readonly int _seconds;

        public WaitCommand(int milliseconds, int seconds, int minutes)
        {
            if (milliseconds < 0) throw new ArgumentException($"{nameof(milliseconds)} must be a positive number.");
            if (seconds < 0) throw new ArgumentException($"{nameof(seconds)} must be a positive number.");
            if (minutes < 0) throw new ArgumentException($"{nameof(minutes)} must be a positive number.");

            _milliseconds = milliseconds;
            _seconds = seconds;
            _minutes = minutes;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            Thread.Sleep(new TimeSpan(0, 0, _minutes, _seconds, _milliseconds));
        }

        public override string ToString()
        {
            return $"Waiting for {_minutes}m, {_seconds}s and {_milliseconds}ms";
        }
    }
}
