using System;

namespace WbTstr.Configuration.WebDrivers.Exceptions
{
    public class WebDriverConfigException : Exception
    {
        public WebDriverConfigException()
        {
        }

        public WebDriverConfigException(string message) : base(message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
        }
    }
}
