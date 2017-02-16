using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    internal class NavigateActionCommand : IActionCommand
    {
        private readonly Uri _uri;

        public NavigateActionCommand(Uri uri)
        {
            _uri = uri;
        }

        public NavigateActionCommand(string url)
        {
            _uri = new Uri(url);
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = webDriverObj as IWebDriver;
            webDriver?.Navigate().GoToUrl(_uri);
        }

        public override string ToString()
        {
            return $"Navigate to {_uri}";
        }
    }
}
