using OpenQA.Selenium;
using WbTstr.Commands.Abstracts;

namespace WbTstr.Commands
{
    internal class MaximizeCommand : WbTstrActionCommand
    {
        public MaximizeCommand()
        {
        }

        /*-------------------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            webDriver.Manage().Window.Maximize();
        }

        public override string ToString()
        {
            return $"Maximize window";
        }
    }
}
