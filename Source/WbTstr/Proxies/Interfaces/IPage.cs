using System;
using System.Collections.Generic;
using System.Drawing;
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

        string InitialHTML { get; }

        string CurrentHTML { get; }

        Size Size { get; }

        IReadOnlyList<string> Console { get; }

        IReadOnlyCollection<ICookie> Cookies { get; }
    }
}
