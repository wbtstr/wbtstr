using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.WebDrivers.Interfaces
{
    public interface IPage
    {
        string Url { get; }

        string Title { get; }

        string Source { get; }

        IReadOnlyCollection<ICookie> Cookies { get; }
    }
}
