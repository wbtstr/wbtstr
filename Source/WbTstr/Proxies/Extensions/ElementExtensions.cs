using OpenQA.Selenium;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.Proxies.Extensions
{
    public static class ElementExtensions
    {
        internal static IWebElement AsWebElement(this IElement element)
        {
            return ElementProxy.AsWebElement(element);
        }
    }
}
