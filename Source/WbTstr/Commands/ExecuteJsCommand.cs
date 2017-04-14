using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private static ReadOnlyCollection<Type> SupportedReturnTypes { get; } = new ReadOnlyCollection<Type>(
          new Type[] {
              typeof(string),
              typeof(long),
              typeof(bool),
              typeof(IElement)
          }
        );

        public ExecuteJsCommand(string jsExpression, bool async = false)
        {
            if (!SupportedReturnTypes.Contains(typeof(T)))
            {
                string message = $"{typeof(T).Name} is not a supported return type. Use 'string', 'bool', 'long' or 'IElement' instead.";
                throw new ArgumentException(message);
            }

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

            if (typeof(T).Equals(typeof(IElement)))
            {
                if (returnValue is IWebElement webElement)
                {
                    IElement element = new Element(webElement);
                    return (T)(element);
                }
            }

            throw new InvalidCastException($"Return value is not of type: {typeof(T).Name}");
        }
    }
}
