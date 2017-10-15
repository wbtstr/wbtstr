using System;
using WbTstr.WebDrivers.Interfaces;
using System.Collections.Generic;
using WbTstr.Proxies.Interfaces;
using System.Drawing;

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

        public string InitialHTML { get; internal set; }

        public string CurrentHTML { get; internal set; }

        public Size Size { get; internal set; }

        public IReadOnlyList<string> Console { get; internal set; }

        public IReadOnlyCollection<ICookie> Cookies { get; internal set; }
    }
}
