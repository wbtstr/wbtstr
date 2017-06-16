using OpenQA.Selenium;
using System;
using System.Linq.Expressions;
using WbTstr.Commands.Abstracts;
using WbTstr.WebDrivers;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.Commands
{
    internal class AssertStateExpCommand : WbTstrActionCommand
    {
        private readonly Expression<Func<WebDriverState, bool>> _expression;

        public AssertStateExpCommand(Expression<Func<WebDriverState, bool>> expression)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        /* Methods ----------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            var webDriverState = new WebDriverState(webDriver);

            var function = _expression.Compile();
            var expected = function(webDriverState);
            if (!expected)
            {
                throw new UnexpectedWebDriverStateException();
            }
        }

        public override string ToString()
        {
            return $"Assert {_expression}";
        }
    }
}
