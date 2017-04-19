using OpenQA.Selenium;
using WbTstr.Commands.Abstracts;

namespace WbTstr.UnitTests._Stubs
{
    internal class ReturnCommandStub : WbTstrReturnCommand<string>
    {
        protected override string Execute(IWebDriver webDriver)
        {
            return string.Empty;
        }
    }
}
