using System;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.Fixtures.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WebDriverConfigAttribute : Attribute
    {
        public WebDriverConfigAttribute(WebDriverType type, WebDriverScope scope = default(WebDriverScope), string preset = null)
        {
            if (type == default(WebDriverType)) throw new ArgumentException(nameof(type));

            Type = type;
            Scope = scope;
            Preset = preset;
        }

        public WebDriverType Type { get; }

        public WebDriverScope Scope { get; }

        public string Preset { get; }
    }
}