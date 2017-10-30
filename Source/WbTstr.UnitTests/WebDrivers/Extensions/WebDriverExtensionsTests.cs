using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.WebDrivers.Extensions;

namespace WbTstr.UnitTests.WebDrivers.Extensions
{
    [TestFixture]
    public class WebDriverExtensionsTests
    {
        [TestCase]
        public void FindElementBySelector_NullSelector_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            TestDelegate action = () => WebDriverExtensions.FindElementBySelector(null, null);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
