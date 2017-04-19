using OpenQA.Selenium;
using System;
using WbTstr.Commands.Abstracts;
using WbTstr.WebDrivers;
using WbTstr.WebDrivers.Constants;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.Commands
{
    internal class AssertStateCommand : WbTstrActionCommand
    {
        private readonly PropertyKey _key;
        private readonly string _value;

        public AssertStateCommand(PropertyKey key, string value)
        {
            _key = key != PropertyKey.None ? key : throw new ArgumentException(nameof(key));
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /* Methods ----------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            if (_key == PropertyKey.Url)
            {
                if (webDriver.Url != _value)
                {
                    throw new UnexpectedWebDriverState($"Url is not {_value}");
                }
            }
            if (_key == PropertyKey.Title)
            {
                if (webDriver.Title != _value)
                {
                    throw new UnexpectedWebDriverState($"Title is not {_value}");
                }
            }
        }

        public override string ToString()
        {
            return $"Assert that {Enum.GetName(_key.GetType(), _key)} equals {_value}";
        }
    }
}
