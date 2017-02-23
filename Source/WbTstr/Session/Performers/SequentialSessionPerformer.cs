using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WbTstr.Commands.Interfaces;
using WbTstr.Configuration.WebDrivers.Interfaces;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Trackers.Interfaces;
using WbTstr.WebDrivers;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.Session.Performers
{
    public class SequentialSessionPerformer : ISessionPerformer
    {
        private readonly Queue<ICommand> _commands;
        private Lazy<IWebDriver> _webDriver;
        private ISessionTracker _tracker;
        private bool _initialized;

        public SequentialSessionPerformer()
        {
            _commands = new Queue<ICommand>();
        }

        public ISessionPerformer Initialize(Lazy<IWebDriverConfig> webDriverConfig, ISessionTracker tracker)
        {
            if (_initialized)
            {
                throw new InvalidOperationException($"{nameof(SequentialSessionPerformer)} can be initialized only once.");
            }

            _webDriver = new Lazy<IWebDriver>(() => WebDriverFactory.CreateFromConfig(webDriverConfig.Value));
            _tracker = tracker;

            _initialized = true;
            return this;
        }

        /* Properties -------------------------------------------------------*/

        public bool DirectPlay { get; set; } = true;

        protected IWebDriver WebDriver => _webDriver?.Value;

        /* Methods ----------------------------------------------------------*/

        public void Perform(IActionCommand actionCommand)
        {
            if (!DirectPlay)
            {
                _commands.Enqueue(actionCommand);
                return;
            }

            ExecuteActionCommand(actionCommand);
        }

        public T PerformAndReturn<T>(IReturnCommand<T> command)
        {
            if (!DirectPlay)
            {
                _commands.Enqueue(command);
            }

            return ExecuteReturnCommand(command);
        }

        public void Play()
        {
            while (_commands.Count != 0)
            {
                var command = _commands.Dequeue();
                if (command is IActionCommand)
                {
                    ExecuteActionCommand(command as IActionCommand);
                }
            }
        }

        private void ExecuteActionCommand(IActionCommand actionCommand)
        {
            try
            {
                _tracker.MarkExecutionBegin(actionCommand);

                actionCommand.Execute(WebDriver);

                _tracker.MarkExecutionEnd(actionCommand);
            }
            catch (UnexpectedWebDriverState)
            {
                Dispose();
                throw;
            }
        }

        private T ExecuteReturnCommand<T>(IReturnCommand<T> command)
        {
            try
            {
                _tracker.MarkExecutionBegin(command);

                var result = command.Execute(WebDriver);

                _tracker.MarkExecutionEnd(command);

                return result;
            }
            catch (UnexpectedWebDriverState)
            {
                Dispose();
                throw;
            }
        }

        /* Finalizer --------------------------------------------------------*/

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || !_webDriver.IsValueCreated) return;

            WebDriver?.Quit();
            WebDriver?.Dispose();
        }
    }
}


