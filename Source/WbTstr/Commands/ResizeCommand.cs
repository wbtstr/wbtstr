using OpenQA.Selenium;
using System;
using System.Drawing;
using WbTstr.Commands.Interfaces;
using WbTstr.WebDrivers;

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
            var webDriver = WebDriverUtilities.ObjectToWebDriver(webDriverObj);

            var window = webDriver?.Manage().Window;
            if (window != null)
            {
                window.Size = new Size(_width, _height);
            }
        }

        public override string ToString()
        {
            return $"Resizing window to {_width}x{_height}";
        }
    }
}
