using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.WebDrivers.Exceptions
{
    public class UnexpectedWebDriverState : WebDriverException
    {
        public UnexpectedWebDriverState(string message) : base(message)
        {
        }
    }
}
