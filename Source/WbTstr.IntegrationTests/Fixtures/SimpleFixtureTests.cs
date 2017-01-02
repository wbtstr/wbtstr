using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WbTstr.IntegrationTests.Fixtures.Auxiliaries;

namespace WbTstr.IntegrationTests.Fixtures
{
    [TestFixture]
    public class SimpleFixtureTests
    {
        [Test]
        public void test()
        {
            var derived = new DerivedFromSimpleFixture();
            derived.TestMethod();
            derived.Dispose();
        }
    }
}
