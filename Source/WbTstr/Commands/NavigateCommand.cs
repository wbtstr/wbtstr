using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    internal class NavigateCommand : ICommand
    {
        private readonly string _url;

        public NavigateCommand(string url)
        {
            _url = url;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = webDriverObj as IWebDriver;
            webDriver?.Navigate().GoToUrl(_url);
        }
    }
}
