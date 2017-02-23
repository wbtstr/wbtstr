using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.Configuration.WebDrivers.Exceptions
{
    public class MissingWebDriverConfigException : WebDriverConfigException
    {
        public MissingWebDriverConfigException()
        {
        }

        public MissingWebDriverConfigException(string message) : base(message)
        {
        }
    }
}
