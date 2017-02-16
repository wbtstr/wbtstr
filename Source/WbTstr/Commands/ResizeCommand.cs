using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    public class ResizeCommand : IActionCommand
    {
        private readonly int _height;
        private readonly int _width;

        public ResizeCommand(int width, int height)
        {
            if (width <= 0) throw new ArgumentException($"{nameof(width)} must be 1 or larger.");
            if (height <= 0) throw new ArgumentException($"{nameof(height)} must be 1 or larger.");

            _width = width;
            _height = height;
        }

        /*-------------------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webdriver = webDriverObj as IWebDriver;
            var window = webdriver?.Manage().Window;

            if (window != null)
            {
                window.Size = new Size(_width, _height);
            }
        }
    }
}
