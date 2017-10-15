using OpenQA.Selenium;
using System;
using System.Threading;
using WbTstr.Commands.Abstracts;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    internal class SetCookieCommand : WbTstrActionCommand
    {
        private readonly string _name;
        private readonly string _value;
        private readonly string _domain;
        private readonly string _path;
        private readonly DateTime? _expiry;

        public SetCookieCommand(string name, string value, string domain, string path, DateTime? expiry)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _value = value ?? throw new ArgumentNullException(nameof(name));
            _domain = domain;
            _path = path;
            _expiry = expiry;
        }

        /* Methods ----------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            var cookies = webDriver.Manage().Cookies;

            var cookie = cookies.GetCookieNamed(_name);
            if (cookie != null)
            {
                cookies.DeleteCookie(cookie);
            }

            if (_path == null)
            {
                cookie = new Cookie(_name, _value);
            }
            else if (_domain == null)
            {
                cookie = new Cookie(_name, _value, _path, _expiry);
            } else
            {
                cookie = new Cookie(_name, _value, _domain, _path, _expiry);
            }

            cookies.AddCookie(cookie);
        }

        public override string ToString()
        {
            return $"Setting cookie '${_name}' to '${_value}.";
        }
    }
}
