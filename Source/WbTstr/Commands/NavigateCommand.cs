using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    internal class NavigateCommand : IActionCommand
    {
        private readonly Uri _uri;

        public NavigateCommand(Uri uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            _uri = uri;
        }

        public NavigateCommand(string url)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));

            _uri = new Uri(url);
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
