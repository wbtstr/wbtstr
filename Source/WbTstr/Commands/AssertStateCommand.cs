using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.WebDrivers.Constants;
using WbTstr.Commands.Interfaces;
using WbTstr.WebDrivers.Exceptions;

namespace WbTstr.Commands
{
    public class AssertStateCommand : ICommand
    {
        private readonly PropertyKey _key;
        private readonly string _value;

        public AssertStateCommand(PropertyKey key, string value)
        {
            _key = key;
            _value = value;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = webDriverObj as IWebDriver;

            if (_key == PropertyKey.Url)
            {
                if (webDriver?.Url != _value)
                {
                    throw new UnexpectedWebDriverState($"Url is not {_value}");
                }
            }
            if (_key == PropertyKey.Title)
            {
                if (webDriver?.Title != _value)
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
