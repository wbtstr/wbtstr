using OpenQA.Selenium;
using WbTstr.Commands.Interfaces;
using WbTstr.WebDrivers;

namespace WbTstr.Commands.Abstracts
{
    internal abstract class WbTstrReturnCommand<T> : IReturnCommand<T>
    {
        public T Execute(object webDriverObj)
        {
            var webDriver = WebDriverUtilities.ObjectToWebDriver(webDriverObj);
            return Execute(webDriver);
        }

        protected abstract T Execute(IWebDriver webDriver);

        public abstract override string ToString();
    }
}
