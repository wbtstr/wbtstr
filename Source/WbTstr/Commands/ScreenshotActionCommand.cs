using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    public class ScreenshotActionCommand : IActionCommand
    {
        private readonly string _fileName;
        private readonly string _directoryPath;

        public ScreenshotActionCommand(string fileName, string directoryPath)
        {
            _fileName = fileName;
            _directoryPath = directoryPath ?? Path.GetTempPath();
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = webDriverObj as IWebDriver;

            var screenshot = webDriver?.TakeScreenshot();
            if (screenshot == null) return;

            var filePath = Path.Combine(_directoryPath, _fileName);
            var imageFormat = DetermineImageFormat(filePath);
            screenshot.SaveAsFile(filePath, imageFormat);
        }

        public override string ToString()
        {
            return $"Take a screenshot ({_fileName})";
        }

        private ImageFormat DetermineImageFormat(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath)?.Substring(1).ToUpper();
            switch (fileExtension)
            {
                case "BMP":
                    return ImageFormat.Bmp;
                case "JPG":
                case "JPEG":
                    return ImageFormat.Jpeg;
                default:
                    return ImageFormat.Png;
            }
        }
    }
}
