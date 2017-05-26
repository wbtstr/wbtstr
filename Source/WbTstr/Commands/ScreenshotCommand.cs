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
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            if (directoryPath == null) throw new ArgumentNullException(nameof(directoryPath));

            bool isValidFileName = MultiPurposeValidator.IsValidFileName(fileName);
            bool isValidDirectoryPath = MultiPurposeValidator.IsValidDirectoryPath(directoryPath);

            _fileName = isValidFileName  ? fileName : throw new ArgumentException(nameof(fileName));
            _directoryPath = isValidDirectoryPath ? directoryPath : throw new ArgumentException(nameof(directoryPath));
        }

        /* Methods ----------------------------------------------------------*/

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
