using OpenQA.Selenium;
using System;
using System.Threading;
using WbTstr.Commands.Abstracts;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    internal class DeleteCookieCommand : WbTstrActionCommand
    {
        private readonly string _name;

        public DeleteCookieCommand(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /* Methods ----------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            var cookies = webDriver.Manage().Cookies;
            cookies.DeleteCookieNamed(_name);
        }

        public override string ToString()
        {
            return $"Deleting cookie '${_name}'.";
        }
    }
}
