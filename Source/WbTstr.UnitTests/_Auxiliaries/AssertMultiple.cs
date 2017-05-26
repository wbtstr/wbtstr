using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.UnitTests._Auxiliaries
{
    public static class AssertMultiple
    {
        public static void Throws<T>(IEnumerable<TestDelegate> testDelegates) where T : Exception
        {
            foreach(TestDelegate testDelegate in testDelegates)
            {
                Assert.Throws<T>(testDelegate);
            }
        }

        public static void DoesNotThrow(IEnumerable<TestDelegate> testDelegates)
        {
            foreach (TestDelegate testDelegate in testDelegates)
            {
                Assert.DoesNotThrow(testDelegate);
            }
        }
    }
}
