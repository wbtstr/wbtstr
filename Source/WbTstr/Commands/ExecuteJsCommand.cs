using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands.Interfaces;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;
using WbTstr.WebDrivers;

namespace WbTstr.Commands
{
    public class ExecuteJsCommand<T> : IReturnCommand<T>
    {
        private readonly string _jsExpression;
        private readonly bool _async;

        public ExecuteJsCommand(string jsExpression, bool async = false)
        {
            _jsExpression = jsExpression ?? throw new ArgumentNullException(nameof(jsExpression)); ;
            _async = async;
        }

        /*-------------------------------------------------------------------*/

        public T Execute(object webDriverObj)
        {
            var webDriver = WebDriverUtilities.ObjectToWebDriver(webDriverObj);
            var jsExecutor = WebDriverUtilities.WebDriverToJavaScriptExecutor(webDriver);

            object returnValue;
            if (_async)
            {
                returnValue = jsExecutor.ExecuteAsyncScript(_jsExpression);
            }
            else
            {
                returnValue = jsExecutor.ExecuteScript(_jsExpression);
            }

            if (returnValue is T)
            {
                return (T)returnValue;
            }

            if (typeof(T) is IElement)
            {
                var webElement = returnValue as IWebElement;
                if (webElement == null)
                {
                    throw new InvalidCastException("Return value is not a Element");
                }

                IElement element = new Element(webElement);
                return (T)(element);
            }

            throw new InvalidCastException($"Return value is not of type: {typeof(T).Name}");
        }
    }
}
