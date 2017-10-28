using System;

namespace WbTstr.Configuration.WebDrivers.Exceptions
{
    public class MissingWebDriverConfigException : WebDriverConfigException
    {
        public MissingWebDriverConfigException()
        {
        }

        public MissingWebDriverConfigException(string message) : base(message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
        }
    }
}
