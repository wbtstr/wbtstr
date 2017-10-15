using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.WebDrivers.Interfaces
{
    public interface IWebDriverState
    {
        string Url { get; }
        string Title { get; }
    }
}
