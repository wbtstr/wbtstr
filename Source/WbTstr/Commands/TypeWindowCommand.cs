using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using WbTstr.Commands.Abstracts;

namespace WbTstr.Commands
{
    internal class TypeWindowCommand : WbTstrActionCommand
    {
        private readonly string _text;
        private readonly bool _clear;

        public TypeWindowCommand(string text) : this(text, false)
        {
        }

        public TypeWindowCommand(string text, bool clear)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            _text = !string.IsNullOrEmpty(text) ? text : throw new ArgumentException(nameof(text));
            _clear = clear;
        }

        /* Methods ----------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
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
