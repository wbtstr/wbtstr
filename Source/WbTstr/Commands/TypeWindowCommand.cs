using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WbTstr.Commands.Interfaces;
using WbTstr.Proxies.Extensions;
using WbTstr.WebDrivers.Extensions;
using WbTstr.WebDrivers;

namespace WbTstr.Commands
{
    public class TypeWindowCommand : IActionCommand
    {
        private readonly string _text;
        private readonly bool _clear;

        public TypeWindowCommand(string text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public TypeWindowCommand(string text, bool clear)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _clear = clear;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = WebDriverUtilities.ObjectToWebDriver(webDriverObj);

            var interaction = new Actions(webDriver);
            interaction.SendKeys(_text);
            interaction.Perform();
        }

        public override string ToString()
        {
            return $"Type '{_text}'";
        }
    }
}
