using System;
using OpenQA.Selenium;
using WbTstr.Commands.Abstracts;
using WbTstr.Commands.Interfaces;
using WbTstr.WebDrivers;
using UriParser = WbTstr.Utilities.UriParser;

namespace WbTstr.Commands
{
    internal class NavigateCommand : WbTstrActionCommand
    {
        private readonly Uri _uri;

        public NavigateCommand(Uri uri)
        {
            _uri = uri ?? throw new ArgumentNullException(nameof(uri));
        }

        public NavigateCommand(string url)
        {
            if (url == null) throw new ArgumentNullException();

            _uri = UriParser.ParseWebUrl(url);
        }

        /* Methods ----------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            webDriver.Navigate().GoToUrl(_uri);
        }

        public override string ToString()
        {
            return $"Navigate to {_uri}";
        }
    }
}
