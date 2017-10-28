using System;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.Utilities
{
    public static class CookieFactory
    {
        public static ICookie Create(string name, string value)
        {
            return new Cookie
            {
                Name = name,
                Value = value
            };
        }
    }
}
