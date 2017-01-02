using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    public class TypeCommand : ICommand
    {
        private readonly string _text;
        private readonly string _selector;

        public TypeCommand(string text, string selector)
        {
            _text = text;
            _selector = selector;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = webDriverObj as IWebDriver;
            var webElement = webDriver?.FindElement(By.CssSelector(_selector));

            webElement?.SendKeys(_text);
        }

        public override string ToString()
        {
            return $"Type '{_text}'";
        }
    }
}
