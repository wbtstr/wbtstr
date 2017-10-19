using OpenQA.Selenium;
using System;
using WbTstr.Commands.Abstracts;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.Commands
{
    internal class SetCookieCommand : WbTstrActionCommand
    {
        private readonly string _name;
        private readonly string _value;
        private readonly string _domain;
        private readonly string _path;
        private readonly DateTime? _expiry;

        public SetCookieCommand(ICookie cookie)
        {
            if (cookie == null) throw new ArgumentNullException(nameof(cookie));

            _name = cookie.Name;
            _value = cookie.Value;
            _domain = cookie.Domain;
            _path = cookie.Path;
            _expiry = cookie.Expiry;
        }

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
