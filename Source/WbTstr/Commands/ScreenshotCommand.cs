using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    public class ScreenshotCommand : IActionCommand
    {
        private readonly string _fileName;
        private readonly string _directoryPath;

        public ScreenshotCommand(string fileName, string directoryPath)
        {
            _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            _directoryPath = directoryPath ?? throw new ArgumentNullException(nameof(directoryPath));
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            if (webDriverObj == null) throw new ArgumentNullException(nameof(webDriverObj));
            var webDriver = webDriverObj as IWebDriver;

            var screenshot = webDriver?.TakeScreenshot();
            if (screenshot == null) return;

            var filePath = Path.Combine(_directoryPath, _fileName);
            var imageFormat = DetermineImageFormat(filePath);
            screenshot.SaveAsFile(filePath, imageFormat);
        }

        private ScreenshotImageFormat DetermineImageFormat(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath)?.Substring(1).ToUpper();
            switch (fileExtension)
            {
                case "BMP":
                    return ScreenshotImageFormat.Bmp;
                case "JPG":
                case "JPEG":
                    return ScreenshotImageFormat.Jpeg;
                default:
                    return ScreenshotImageFormat.Png;
            }
        }

        public override string ToString()
        {
            return $"Take a screenshot ({_fileName})";
        }
    }
}
