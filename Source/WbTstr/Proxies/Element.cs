using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.Proxies
{
    public class Element : IElement
    {
        private readonly IWebElement _webElement;

        internal Element(IWebElement webElement)
        {
            _webElement = webElement;

        }

        /*-------------------------------------------------------------------*/

        public string TagName => _webElement.TagName;
    }
}
