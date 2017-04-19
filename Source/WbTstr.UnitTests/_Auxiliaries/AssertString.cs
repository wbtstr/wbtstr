using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.UnitTests._Auxiliaries
{
    public static class AssertString
    {
        public static void NotNullOrEmpty(string value)
        {
            Assert.False(string.IsNullOrEmpty(value));
        }

        public static void NotNullOrWhiteSpace(string value)
        {
            Assert.False(string.IsNullOrWhiteSpace(value));
        }
    }
}
