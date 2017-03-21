using OpenQA.Selenium;
using System;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    internal class NavigateCommand : IActionCommand
    {
        private readonly Uri _uri;

        public NavigateCommand(Uri uri)
        {
            _uri = uri ?? throw new ArgumentNullException(nameof(uri));
        }

        public NavigateCommand(string url)
        {
            _uri = new Uri(url ?? throw new ArgumentNullException(nameof(url)));
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            if (webDriverObj == null) throw new ArgumentNullException(nameof(webDriverObj));
            var webDriver = webDriverObj as IWebDriver;

            webDriver?.Navigate().GoToUrl(_uri);
        }

        public override string ToString()
        {
            return $"Navigate to {_uri}";
        }
    }
}
