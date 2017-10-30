using System;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.Utilities
{
    public static class CookieFactory
    {
        public static ICookie Create(string name, string value, string domain = null, string path = null, DateTime? expiry = null)
        {
            return new Cookie
            {
                Name = name,
                Value = value,
                Domain = null,
                Path = null,
                Secure = false,
                IsHttpOnly = false,
                Expiry = null
            };
        }
    }
}
