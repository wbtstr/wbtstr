using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.Proxies.Interfaces
{
    public interface IElement
    {
        string TagName { get; }

        string Text { get; }

        bool Enabled { get; }

        bool Selected { get; }

        bool Displayed { get; }

        string GetAttribute(string name);

        string GetCssValue(string property);

        int Height { get; }

        int Width { get; }

        int UpperLeftCornerX { get; }

        int UpperLeftCornerY { get; }
    }
}
