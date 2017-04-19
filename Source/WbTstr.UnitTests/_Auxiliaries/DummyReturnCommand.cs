using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.Commands.Abstracts;

namespace WbTstr.UnitTests._Auxiliaries
{
    internal class DummyReturnCommand : WbTstrReturnCommand<string>
    {
        protected override string Execute(IWebDriver webDriver)
        {
            return string.Empty;
        }
    }
}
