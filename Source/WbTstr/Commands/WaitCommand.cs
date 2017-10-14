using OpenQA.Selenium;
using System;
using System.Threading;
using WbTstr.Commands.Abstracts;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    internal class WaitCommand : WbTstrActionCommand
    {
        private readonly TimeSpan _duration;

        public WaitCommand(TimeSpan duration)
        {
            _duration = duration;
        }

        /* Methods ----------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            Thread.Sleep(_duration);
        }

        public override string ToString()
        {
            return $"Waiting for {_duration.Minutes}m, {_duration.Seconds}s and {_duration.Milliseconds}ms";
        }
    }
}
