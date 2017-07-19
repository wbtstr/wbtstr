using System;

namespace WbTstr.WebDrivers.Exceptions
{
    public class ElementNotFoundException : WebDriverException
    {
        public ElementNotFoundException()
        {
        }

        public ElementNotFoundException(string message) : base(message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
        }
    }
}
