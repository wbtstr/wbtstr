using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    public class WaitCommand : ICommand
    {
        private readonly int _miliseconds;
        private readonly int _minutes;
        private readonly int _seconds;

        public WaitCommand(int miliseconds, int seconds, int minutes)
        {
            _miliseconds = miliseconds;
            _seconds = seconds;
            _minutes = minutes;
        }

        public void Execute(object webDriverObj)
        {
            Thread.Sleep(new TimeSpan(0, 0, _minutes, _seconds, _miliseconds));
        }
    }
}
