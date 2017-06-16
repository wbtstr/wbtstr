using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.WebDrivers.Constants;

namespace WbTstr.Fixtures.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WebDriverConfigAttribute : Attribute
    {
        public WebDriverConfigAttribute(WebDriverType type, string preset = null)
        {
            if (type == default(WebDriverType)) throw new ArgumentException(nameof(type));

            Type = type;
            Preset = preset;
        }

        public WebDriverConfigAttribute(string type, string preset = null)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (string.IsNullOrWhiteSpace(type)) throw new ArgumentException(nameof(type));

            Type = (WebDriverType)Enum.Parse(typeof(WebDriverType), type, true);
            Preset = preset;
        }

        public WebDriverType Type { get; }

        public string Preset { get; }
    }
}