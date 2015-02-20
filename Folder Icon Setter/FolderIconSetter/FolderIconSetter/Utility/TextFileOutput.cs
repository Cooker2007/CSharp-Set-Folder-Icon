// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextFileOutput.cs" company="">
//
// </copyright>
// <summary>
//   The text file output.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FolderIconSetter.Utility
{
    using System.IO;

    /// <summary>
    /// The text file output.
    /// </summary>
    internal static class TextFileOutput
    {
        /// <summary>
        /// Writes the text file needed to display the Icon. I can only handle single image .ico files.
        /// </summary>
        /// <param name="isRoot">
        /// Determines if "autorun.inf" or "desktop.ini" is used.
        /// </param>
        /// <param name="displayFolderPath">
        /// </param>
        /// <param name="iconFullPath">
        /// </param>
        /// <param name="driveLabel">
        /// Text for the system to display for the hard drive or flash drive name.
        /// </param>
        public static void WriteNew(bool isRoot, string displayFolderPath, string iconFullPath, string driveLabel = "")
        {
            if (isRoot)
            {
                WriteAutorunInf(displayFolderPath, iconFullPath, driveLabel);
            }
            else
            {
                WriteDesktopIni(displayFolderPath, iconFullPath);
            }
        }

        /// <summary>
        /// Creates the text for the autorun.inf file in the root of drives
        /// </summary>
        /// <param name="displayFolderPath">
        /// </param>
        /// <param name="iconFullPath">
        /// </param>
        /// <param name="driveLabel">
        /// </param>
        private static void WriteAutorunInf(string displayFolderPath, string iconFullPath, string driveLabel)
        {
            string relativePath = Utilities.MakeRelativePath(displayFolderPath + "\\autorun.inf", iconFullPath);

            using (StreamWriter outputFile = new StreamWriter(displayFolderPath + "\\autorun.inf"))
            {
                outputFile.WriteLine("[Autorun]");
                outputFile.Write("Icon=\"{0}\"", relativePath);

                if (driveLabel != string.Empty)
                {
                    outputFile.WriteLine("Label=\"{0}\"", driveLabel);
                }
            }
        }

        /// <summary>
        /// Creates the text for the desktop.ini file for all non-root folders.
        /// </summary>
        /// <param name="displayFolderPath">
        /// </param>
        /// <param name="iconFullPath">
        /// </param>
        private static void WriteDesktopIni(string displayFolderPath, string iconFullPath)
        {
            string relativePath = Utilities.MakeRelativePath(displayFolderPath + "\\desktop.ini", iconFullPath);

            using (StreamWriter outputFile = new StreamWriter(displayFolderPath + "\\desktop.ini"))
            {
                outputFile.WriteLine("[.ShellClassInfo]");

                // No space between the comma and 0!
                outputFile.Write("IconResource=\"{0}\",0", relativePath);
            }
        }
    }
}