using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
using WbTstr.Commands.Abstracts;
using WbTstr.Utilities;

namespace WbTstr.Commands
{
    internal class ScreenshotCommand : WbTstrActionCommand
    {
        private readonly string _fileName;
        private readonly string _directoryPath;

        public ScreenshotCommand(string fileName, string directoryPath)
        {
            _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            _directoryPath = directoryPath ?? throw new ArgumentNullException(nameof(directoryPath));

            if (MultiPurposeValidator.IsValidFileName(fileName))
            {
                throw new ArgumentException($"Invalid file name: {fileName}");
            }
            if (MultiPurposeValidator.IsValidDirectoryPath(directoryPath))
            {
                throw new ArgumentException($"Invalid directory: {directoryPath}");
            }
        }

        /*-------------------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            var screenshot = webDriver.TakeScreenshot();
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
