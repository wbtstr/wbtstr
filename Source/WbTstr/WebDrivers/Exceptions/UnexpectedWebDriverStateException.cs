using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.WebDrivers.Exceptions
{
    public class UnexpectedWebDriverStateException : WebDriverException
    {
        public UnexpectedWebDriverStateException()
        {
        }

        public UnexpectedWebDriverStateException(string message) : base(message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
        }
    }
}
