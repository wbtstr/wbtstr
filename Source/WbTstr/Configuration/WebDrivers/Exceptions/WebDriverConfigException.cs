using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.Configuration.WebDrivers.Exceptions
{
    public class WebDriverConfigException : Exception
    {
        public WebDriverConfigException()
        {
        }

        public WebDriverConfigException(string message) : base(message)
        {
        }
    }
}
