using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Utilities;

namespace WbTstr.UnitTests.Utilities
{
    [TestFixture]
    public class CookieFactoryTests
    {
        [TestCase]
        public void Create_NullParameters_DoesNotThrow()
        {
            // Arrange

            // Act
            TestDelegate action = () => CookieFactory.Create(null, null);

            // Assert
            Assert.DoesNotThrow(action);
        }
    }
}
