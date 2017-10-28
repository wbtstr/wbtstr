using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using WbTstr.Commands.Abstracts;
using WbTstr.Proxies.Extensions;
using WbTstr.Proxies.Interfaces;
using WbTstr.WebDrivers.Extensions;

namespace WbTstr.Commands
{
    internal class SelectCommand : WbTstrActionCommand
    {
        private readonly string _selector;
        private readonly IElement _element;
        private readonly string[] _texts;
        private readonly int[] _indexes;

        public SelectCommand(string selector, params string[] texts)
        {
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));
            _texts = texts;
        }

        public SelectCommand(string selector, params int[] indexes)
        {
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));
            _indexes = indexes;
        }

        public SelectCommand(IElement element, params string[] texts)
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
            _texts = texts;
        }

        public SelectCommand(IElement element, params int[] indexes)
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
            _indexes = indexes;
        }

        /*-------------------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            var webElement = _element?.AsWebElement() ?? webDriver.FindElementBySelector(_selector);
            if (webElement != null)
            {
                var select = new SelectElement(webElement);
                if (select.IsMultiple)
                {
                    select.DeselectAll();
                }

                if (_texts != null)
                {
                    foreach (var text in _texts)
                    {
                        select.SelectByText(text);
                    }
                }

                if (_indexes != null)
                {
                    foreach (var index in _indexes)
                    {
                        select.SelectByIndex(index);
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"Selecting items in select element.";
        }
    }
}
