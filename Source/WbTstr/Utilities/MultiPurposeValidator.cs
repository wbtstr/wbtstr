using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.Utilities
{
    public static class MultiPurposeValidator
    {
        public static bool IsValidFileName(string fileName)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));

            try
            {
                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    new FileInfo(fileName);
                    return true;
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return false;
        }

        public static bool IsValidDirectoryPath(string directoryPath)
        {
            if (directoryPath == null) throw new ArgumentNullException(nameof(directoryPath));

            try
            {
                if (!string.IsNullOrWhiteSpace(directoryPath))
                {
                    new DirectoryInfo(directoryPath);
                    return true;
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return false;
        }
    }
}
