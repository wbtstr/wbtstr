using System;

namespace WbTstr.WebDrivers.Exceptions
{
    public class WebDriverException : Exception
    {
        public WebDriverException()
        {
        }

        public WebDriverException(string message) : base(message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
        }
    }
}
