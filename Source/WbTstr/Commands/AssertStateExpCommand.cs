using OpenQA.Selenium;
using System;
using System.Linq.Expressions;
using WbTstr.Commands.Interfaces;
using WbTstr.WebDrivers;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.Commands
{
    internal class AssertStateExpCommand : IActionCommand
    {
        private readonly Expression<Func<WebDriverState, bool>> _expression;

        public AssertStateExpCommand(Expression<Func<WebDriverState, bool>> expression)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = WebDriverUtilities.ObjectToWebDriver(webDriverObj);
            var webDriverState = new WebDriverState(webDriver);

            var function = _expression.Compile();
            var expected = function(webDriverState);
            if (!expected)
            {
                throw new UnexpectedWebDriverState();
            }
        }

        public override string ToString()
        {
            return $"Assert {_expression}";
        }
    }
}
