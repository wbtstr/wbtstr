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
using WbTstr.WebDrivers;

namespace WbTstr.Session.Performers
{
    public class SequentialSessionPerformer : ISessionPerformer
    {
        private readonly Queue<ICommand> _commands;
        private IWebDriver _webDriver;
        private bool _initialized;

        public SequentialSessionPerformer()
        {
            _commands = new Queue<ICommand>();
        }

        public ISessionPerformer Initialize(IWebDriverConfig webDriverConfig)
        {
            if (_initialized)
            {
                throw new InvalidOperationException($"{nameof(SequentialSessionPerformer)} can be initialized only once.");
            }

            _webDriver = WebDriverFactory.CreateFromConfig(webDriverConfig);

            _initialized = true;
            return this;
        }

        /* Properties -------------------------------------------------------*/

        public bool DirectPlay { get; set; } = true;

        /* Methods ----------------------------------------------------------*/

        public void Perform(ICommand command)
        {
            if (!DirectPlay)
            {
                _commands.Enqueue(command);
                return;
            }

            command.Execute(_webDriver);
        }

        public void Play()
        {
            while (_commands.Count != 0)
            {
                var command = _commands.Dequeue();
                command.Execute(_webDriver);
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
            if (!disposing || _webDriver == null) return;

            _webDriver.Quit();
            _webDriver.Dispose();
        }
    }
}


