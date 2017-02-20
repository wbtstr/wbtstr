using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.WebDrivers.Constants;
using WbTstr.Commands.Interfaces;
using WbTstr.WebDrivers.Exceptions;
using WbTstr.WebDrivers;

namespace WbTstr.Commands
{
    public class AssertStateCommand : IActionCommand
    {
        private readonly PropertyKey _key;
        private readonly string _value;

        public AssertStateCommand(PropertyKey key, string value)
        {
            if (key == default(PropertyKey)) throw new ArgumentException(nameof(key));
            if (value == null) throw new ArgumentNullException(nameof(value));

            _key = key;
            _value = value;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = WebDriverUtilities.ObjectToWebDriver(webDriverObj);

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
