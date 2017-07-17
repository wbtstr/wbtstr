using System;

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
