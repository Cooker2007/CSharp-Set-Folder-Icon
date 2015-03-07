namespace FolderIconSetter.Utility
{
    using System;
    using System.IO;
    using System.Text;
    using FolderIconSetter.Model;

    /// <summary>
    /// The text file output.
    /// </summary>
    internal static class TextFileOutput
    {
        /// <summary>
        /// Writes the text file to display the custom folder icon.
        /// </summary>
        /// <param name="paths">Reference to the SelectedPaths class.</param>
        public static void WriteNew(SelectedPaths paths)
        {
            // Updated Method to write file
            string fileName = paths.IsRoot ? "\\autorun.inf" : "\\desktop.ini";
            string fileContents = paths.IsRoot ?
                MakeAutorunInfContents(paths.RelativePath) :
                MakeDesktopIniContents(paths.RelativePath, paths.DriveName);

            using (StreamWriter outputFile = new StreamWriter(paths.FolderPath + fileName))
            {
                outputFile.Write(fileContents);
            }
        }

        /// <summary>
        /// Makes the text for the autorun.inf file.
        /// </summary>
        /// <param name="relativePath">The relative path between the folder and the icon file.</param>
        /// <returns>Returns a string.</returns>
        private static string MakeAutorunInfContents(string relativePath)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[.ShellClassInfo]");
            sb.Append(Environment.NewLine);

            // No space between the comma and the 0
            sb.AppendFormat("IconResource=\"{0}\",0", relativePath);
            
            return sb.ToString();
        }

        /// <summary>
        /// Makes the text contents for the desktop.ini file.
        /// </summary>
        /// <param name="relativePath">The relative path between the folder and the icon file.</param>
        /// <param name="driveName">Custom drive name the user chose.</param>
        /// <returns>Returns a string</returns>
        private static string MakeDesktopIniContents(string relativePath, string driveName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Autorun]");
            sb.Append(Environment.NewLine);
            sb.AppendFormat("Icon=\"{0}\"", relativePath);

            if (driveName != string.Empty)
            {
                sb.Append(Environment.NewLine);
                sb.AppendFormat("Label=\"{0}\"", driveName);
            }

            return sb.ToString();
        }
    }
}