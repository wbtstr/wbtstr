using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WbTstr.UnitTests._Auxiliaries;
using WbTstr.Utilities;

namespace WbTstr.UnitTests.Utilities
{
    [TestFixture]
    public class MultiPursposeValidatorTests
    {
        [TestCase]
        public void IsValidFileName_NullInput_ThrowsNullArgumentException()
        {
            // Arrange
            string fileName = null;

            // Act
            TestDelegate action = () => MultiPurposeValidator.IsValidFileName(fileName);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void IsValidFileName_InvalidInput_DoesNotThrowException()
        {
            // Arrange

            // Act
            TestDelegate[] actions =
            {
                () => MultiPurposeValidator.IsValidFileName(""),
                () => MultiPurposeValidator.IsValidFileName("  "),
                () => MultiPurposeValidator.IsValidFileName("file name"),
                () => MultiPurposeValidator.IsValidFileName("<?>")
            };

            // Assert
            AssertMultiple.DoesNotThrow(actions);
        }

        [TestCase]
        public void IsValidFileName_InvalidInput_ReturnsFalse()
        {
            // Arrange

            // Act
            Func<bool>[] actions =
            {
                () => MultiPurposeValidator.IsValidFileName(""),
                () => MultiPurposeValidator.IsValidFileName("  "),
                () => MultiPurposeValidator.IsValidFileName("file*name"),
                () => MultiPurposeValidator.IsValidFileName("<?>")
            };

            // Assert
            AssertMultiple.Returns(actions, false);
        }

        [TestCase]
        public void IsValidFileName_ValidInput_ReturnsTrue()
        {
            // Arrange

            // Act
            Func<bool>[] actions =
            {
                () => MultiPurposeValidator.IsValidFileName("image.jpg"),
                () => MultiPurposeValidator.IsValidFileName("image.unkown"),
                () => MultiPurposeValidator.IsValidFileName("directory/filename.png"),
                () => MultiPurposeValidator.IsValidFileName("filename_noext")
            };

            // Assert
            AssertMultiple.Returns(actions, true);
        }

        [TestCase]
        public void IsValidDirectoryPath_NullInput_ThrowsNullArgumentException()
        {
            // Arrange
            string directoryPath = null;

            // Act
            TestDelegate action = () => MultiPurposeValidator.IsValidDirectoryPath(directoryPath);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void IsValidDirectoryPath_InvalidInput_DoesNotThrowException()
        {
            // Arrange

            // Act
            TestDelegate[] actions =
            {
                () => MultiPurposeValidator.IsValidFileName(""),
                () => MultiPurposeValidator.IsValidFileName("  "),
                () => MultiPurposeValidator.IsValidFileName("directory*path"),
                () => MultiPurposeValidator.IsValidFileName("<?>")
            };

            // Assert
            AssertMultiple.DoesNotThrow(actions);
        }

        [TestCase]
        public void IsValidDirectoryPath_InvalidInput_ReturnsFalse()
        {
            // Arrange

            // Act
            Func<bool>[] actions =
            {
                () => MultiPurposeValidator.IsValidFileName(""),
                () => MultiPurposeValidator.IsValidFileName("  "),
                () => MultiPurposeValidator.IsValidFileName("directory*path"),
                () => MultiPurposeValidator.IsValidFileName("<?>")
            };

            // Assert
            AssertMultiple.Returns(actions, false);
        }

        [TestCase]
        public void IsValidDirectoryPath_ValidInput_ReturnsTrue()
        {
            // Arrange

            // Act
            Func<bool>[] actions =
            {
                () => MultiPurposeValidator.IsValidFileName("sub/sub/sub\\sap\\sap\\sap"),
                () => MultiPurposeValidator.IsValidFileName("%TEMP%"),
                () => MultiPurposeValidator.IsValidFileName("C://Windows/System32"),
                () => MultiPurposeValidator.IsValidFileName("folder_only")
            };

            // Assert
            AssertMultiple.Returns(actions, true);
        }
    }
}
