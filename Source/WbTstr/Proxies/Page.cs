using System;
using WbTstr.WebDrivers.Interfaces;
using System.Collections.Generic;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.WebDrivers
{
    public class Page : IPage
    {
        internal Page()
        {
        }

        /* Properties -------------------------------------------------------*/

        public string Url { get; internal set; }

        public string Title { get; internal set; }

        public string Source { get; internal set; }

        public IReadOnlyCollection<ICookie> Cookies { get; internal set; }
    }
}
