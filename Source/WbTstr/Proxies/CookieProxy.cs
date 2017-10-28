using System;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.Proxies
{
    public class CookieProxy : ICookie
    {
        private readonly OpenQA.Selenium.Cookie _cookie;

        internal CookieProxy(OpenQA.Selenium.Cookie cookie)
        {
            _cookie = cookie;
        }

        /*-------------------------------------------------------------------*/

        public string Name => _cookie.Name;

        public string Value => _cookie.Value;

        public string Domain => _cookie.Domain;

        public string Path => _cookie.Path;

        public bool Secure => _cookie.Secure;

        public bool IsHttpOnly => _cookie.IsHttpOnly;

        public DateTime? Expiry => _cookie.Expiry;
    }
}
