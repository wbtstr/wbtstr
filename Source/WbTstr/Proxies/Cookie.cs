using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.Proxies
{
    public class Cookie : ICookie
    {
        private readonly OpenQA.Selenium.Cookie _cookie;

        internal Cookie(OpenQA.Selenium.Cookie cookie)
        {
            _cookie = cookie;
        }

        /* Properties -------------------------------------------------------*/

        public string Name => _cookie.Name;

        public string Value => _cookie.Value;

        public string Domain => _cookie.Domain;

        public string Path => _cookie.Path;

        public bool Secure => _cookie.Secure;

        public bool IsHttpOnly => _cookie.IsHttpOnly;

        public DateTime? Expiry => _cookie.Expiry;
    }
}
