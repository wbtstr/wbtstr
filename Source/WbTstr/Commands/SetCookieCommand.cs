using OpenQA.Selenium;
using System;
using WbTstr.Commands.Abstracts;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.Commands
{
    internal class SetCookieCommand : WbTstrActionCommand
    {
        private readonly ICookie _cookie;

        public SetCookieCommand(ICookie cookie)
        {
            _cookie = cookie ?? throw new ArgumentNullException(nameof(cookie));
        }

        /*-------------------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            var cookies = webDriver.Manage().Cookies;

            var cookie = cookies.GetCookieNamed(_cookie.Name);
            if (cookie != null)
            {
                cookies.DeleteCookie(cookie);
            }

            if (_cookie.Path == null)
            {
                cookie = new Cookie(_cookie.Name, _cookie.Value);
            }
            else if (_cookie.Domain == null)
            {
                cookie = new Cookie(_cookie.Name, _cookie.Value, _cookie.Path, _cookie.Expiry);
            } else
            {
                cookie = new Cookie(_cookie.Name, _cookie.Value, _cookie.Domain, _cookie.Path, _cookie.Expiry);
            }

            cookies.AddCookie(cookie);
        }

        public override string ToString()
        {
            return $"Setting cookie '${_cookie.Name}' to '${_cookie.Value}.";
        }
    }
}
