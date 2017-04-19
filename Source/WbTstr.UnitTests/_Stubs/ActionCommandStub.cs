using OpenQA.Selenium;
using WbTstr.Commands.Abstracts;

namespace WbTstr.UnitTests._Stubs
{
    internal class ActionCommandStub : WbTstrActionCommand
    {
        protected override void Execute(IWebDriver webDriver)
        {
        }
    }
}
