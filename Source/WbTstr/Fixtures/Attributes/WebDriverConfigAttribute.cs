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
            Type = type;
            Preset = preset;
        }

        public WebDriverConfigAttribute(string type, string preset = null)
        {
            Type = (WebDriverType)Enum.Parse(typeof(WebDriverType), type, true);
            Preset = preset;
        }

        public WebDriverType Type { get; }

        public string Preset { get; }
    }
}