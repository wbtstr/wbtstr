using OpenQA.Selenium;
using WbTstr.Commands.Interfaces;
using WbTstr.WebDrivers;

namespace WbTstr.Commands.Abstracts
{
    internal abstract class WbTstrActionCommand : IActionCommand
    {
        public void Execute(object webDriverObj)
        {
            var webDriver = WebDriverUtilities.ObjectToWebDriver(webDriverObj);
            Execute(webDriver);
        }

        protected abstract void Execute(IWebDriver webDriver);

        public abstract override string ToString();
    }
}
