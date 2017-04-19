using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using WbTstr.Commands.Abstracts;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;
using WbTstr.WebDrivers;

namespace WbTstr.Commands
{
    internal class ExecuteJsCommand<T> : WbTstrReturnCommand<T>
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

        protected override T Execute(IWebDriver webDriver)
        {
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

        public override string ToString()
        {
            return "TODO: ExecuteJsCommand.ToString()";
        }
    }
}
