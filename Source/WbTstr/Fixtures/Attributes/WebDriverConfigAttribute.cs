using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.Fixtures.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WebDriverConfigAttribute : Attribute
    {
        public WebDriverConfigAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}