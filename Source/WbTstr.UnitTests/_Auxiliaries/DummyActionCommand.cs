using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.Commands.Abstracts;

namespace WbTstr.UnitTests._Auxiliaries
{
    internal class DummyActionCommand : WbTstrActionCommand
    {
        protected override void Execute(IWebDriver webDriver)
        {
        }
    }
}
