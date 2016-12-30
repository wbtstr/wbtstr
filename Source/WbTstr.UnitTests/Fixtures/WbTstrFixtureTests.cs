using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WbTstr.UnitTests.Fixtures.Auxiliaries;

namespace WbTstr.UnitTests.Fixtures
{
    [TestFixture]
    public class WbTstrFixtureTests
    {
        [Test]
        public void test()
        {
            var derived = new DerivedFromWbTstrFixture();
        }
    }
}
