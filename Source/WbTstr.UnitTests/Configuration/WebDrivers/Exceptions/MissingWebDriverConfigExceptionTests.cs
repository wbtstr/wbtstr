using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using WbTstr.Configuration.WebDrivers.Exceptions;
using WbTstr.UnitTests._Auxiliaries;
using NUnit.Framework;

namespace WbTstr.UnitTests.Configuration.WebDrivers.Exceptions
{
    [TestFixture]
    public class MissingWebDriverConfigExceptionTests : CustomExceptionTests<MissingWebDriverConfigException>
    {
    }
}
