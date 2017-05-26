using OpenQA.Selenium;
using WbTstr.Commands.Abstracts;

namespace WbTstr.UnitTests._Stubs
{
    internal class ActionCommandStub : WbTstrActionCommand
    {
        protected override void Execute(IWebDriver webDriver)
        {
        }

        public override string ToString()
        {
            return "ActionCommandStub.ToString()";
        }
    }
}
