using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using WbTstr.Commands.Abstracts;

namespace WbTstr.Commands
{
    internal class AuthenticateCommand : WbTstrActionCommand
    {
        private readonly string _username;
        private readonly string _password;
        private readonly TimeSpan _timeout;

        public AuthenticateCommand(string username, string password, TimeSpan timeout)
        {
            _username = username;
            _password = password;
            _timeout = timeout;
        }

        /* Methods ----------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            var wait = new WebDriverWait(webDriver, _timeout);
            var alert = wait.Until(ExpectedConditions.AlertIsPresent());

            alert.SetAuthenticationCredentials(_username, _password);
            alert.Accept();
        }

        public override string ToString()
        {
            return $"Authenticating with U: ${_username} and P: ${_password}.";
        }
    }
}
