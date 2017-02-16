using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.Proxies.Extensions
{
    public static class ElementExtensions
    {
        internal static IWebElement AsWebElement(this IElement element)
        {
            return Element.AsWebElement(element);
        }
    }
}
