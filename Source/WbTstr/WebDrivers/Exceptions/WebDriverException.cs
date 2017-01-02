using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.WebDrivers.Exceptions
{
    public class WebDriverException : Exception
    {
        public WebDriverException()
        {
        }

        public WebDriverException(string message) : base(message)
        {
        }
    }
}
