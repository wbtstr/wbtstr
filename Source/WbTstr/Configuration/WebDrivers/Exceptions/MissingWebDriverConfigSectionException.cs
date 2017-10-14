using System;

namespace WbTstr.Configuration.WebDrivers.Exceptions
{
    public class MissingWebDriverConfigSectionException : WebDriverConfigException
    {
        public MissingWebDriverConfigSectionException()
        {
        }

        public MissingWebDriverConfigSectionException(string message) : base(message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
        }
    }
}
