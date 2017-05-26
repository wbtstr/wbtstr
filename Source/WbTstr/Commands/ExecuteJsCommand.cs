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
              typeof(IElement),
          }
        );

        public ExecuteJsCommand(string jsExpression, bool async = false)
        {
            if (jsExpression == null) throw new ArgumentNullException(nameof(jsExpression));

            _jsExpression = !string.IsNullOrWhiteSpace(jsExpression) ? jsExpression : throw new ArgumentException(nameof(jsExpression));
            _async = async;

            if (!SupportedReturnTypes.Contains(typeof(T)))
            {
                string message = $"{typeof(T).Name} is not a supported return type. Use 'string', 'bool', 'long' (Int64) or 'IElement' instead.";
                throw new ArgumentException(message);
            }
        }

        /*-------------------------------------------------------------------*/

        protected override T Execute(IWebDriver webDriver)
        {
            var jsExecutor = WebDriverUtilities.WebDriverToJavaScriptExecutor(webDriver);

            if (_async)
            {
                if (typeof(T) == typeof(IElement))
                {
                    return PerformJsAsyncAndReturnElement(jsExecutor, _jsExpression);
                }
                else
                {
                    return PerformJsAsyncAndReturnPrimitive(jsExecutor, _jsExpression);
                }
            }
            else
            {
                if (typeof(T) == typeof(IElement))
                {
                    return PerformJsSyncAndReturnElement(jsExecutor, _jsExpression);
                }
                else
                {
                    return PerformJsSyncAndReturnPrimitive(jsExecutor, _jsExpression);
                }
            }
        }

        public virtual T PerformJsSyncAndReturnPrimitive(IJavaScriptExecutor jsExecutor, string jsExpression)
        {
            return (T)jsExecutor.ExecuteScript(_jsExpression);
        }

        public virtual T PerformJsAsyncAndReturnPrimitive(IJavaScriptExecutor jsExecutor, string jsExpression)
        {
            return (T)jsExecutor.ExecuteAsyncScript(_jsExpression);
        }

        public virtual T PerformJsSyncAndReturnElement(IJavaScriptExecutor jsExecutor, string jsExpression)
        {
            if (jsExecutor.ExecuteScript(_jsExpression) is IWebElement returnValue)
            {
                IElement element = new Element(returnValue);
                return (T)element;
            }

            throw new InvalidCastException($"Return value is not of type: {typeof(T).Name}");
        }

        public virtual T PerformJsAsyncAndReturnElement(IJavaScriptExecutor jsExecutor, string jsExpression)
        {
            if (jsExecutor.ExecuteAsyncScript(_jsExpression) is IWebElement returnValue)
            {
                IElement element = new Element(returnValue);
                return (T)element;
            }

            throw new InvalidCastException($"Return value is not of type: {typeof(T).Name}");
        }

        public override string ToString()
        {
            return "TODO: ExecuteJsCommand.ToString()";
        }
    }
}
