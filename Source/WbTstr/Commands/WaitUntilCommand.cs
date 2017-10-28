using OpenQA.Selenium;
using System;
using System.Threading;
using WbTstr.Commands.Abstracts;

namespace WbTstr.Commands
{
    internal class WaitUntilCommand : WbTstrActionCommand
    {
        private readonly Func<bool> _predicate;
        private readonly TimeSpan _interval;
        private readonly TimeSpan _timeout;

        public WaitUntilCommand(Func<bool> predicate, TimeSpan interval, TimeSpan timeout)
        {
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _interval = interval;
            _timeout = timeout;
        }

        /*-------------------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            Func<bool> checkPredicate = () =>
            {
                try
                {
                    return _predicate();
                }
                catch (Exception)
                {
                    return false;
                }
            };

            var timeout = DateTime.Now + _timeout;
            while (!checkPredicate())
            {
                Thread.Sleep(_interval);
                if (DateTime.Now > timeout)
                {
                    throw new Exception("WaitUntil timeout");
                }
            }
        }

        public override string ToString()
        {
            return $"Waiting until predicate turns true.";
        }
    }
}
