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
        public WebDriverConfigAttribute(WebDriverName name)
        {
            Name = name;
        }

        public WebDriverConfigAttribute(string name)
        {
            Name = (WebDriverName) Enum.Parse(typeof(WebDriverName), name, true);
        }

        public WebDriverName Name { get; }
    }
}