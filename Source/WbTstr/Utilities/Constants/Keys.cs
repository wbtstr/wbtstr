using System;
using System.Globalization;

namespace WbTstr.Utilities.Constants
{
    public static class Keys
    {
        /// <summary>
        /// String representation of the Enter key.
        /// </summary>
        public static readonly string Enter = Convert.ToString(Convert.ToChar(0xE007, CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
    }
}