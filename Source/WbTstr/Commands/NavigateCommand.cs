using OpenQA.Selenium;
using System;
using WbTstr.Commands.Abstracts;
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
            _uri = UriParser.ParseWebUrl(url ?? throw new ArgumentNullException(nameof(url)));
        }

        /*-------------------------------------------------------------------*/

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
