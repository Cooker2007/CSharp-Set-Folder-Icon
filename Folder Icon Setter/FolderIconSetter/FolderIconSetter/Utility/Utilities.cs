namespace FolderIconSetter.Utility
{
    using System;
    using System.IO;

    static class Utilities
    {
        /// <summary>
        /// Determines if the selected folders have the same root path
        /// </summary>
        /// <returns>Returns a bool value</returns>
        public static bool AreRootsSame(string path1, string path2)
        {
            bool result = !String.IsNullOrWhiteSpace(path1)
                       && !String.IsNullOrWhiteSpace(path2)
                       && Path.GetPathRoot(path1).Equals(Path.GetPathRoot(path2));

            return result;
        }


        public static string MakeRelativePath(string sourcePath, string destinationPath)
        {
            Uri uri = new Uri(sourcePath);
            string relativePath = uri.MakeRelativeUri(new Uri(destinationPath)).ToString();
           
            relativePath = relativePath.Replace('/', '\\');
            relativePath = relativePath.Replace("%20", " ");

            return relativePath;
        }

        /// <summary>
        /// Checks if a FileAttributes contains the specified attribute.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="matchTo"></param>
        /// <returns>Returns bool, true if contains Attribute</returns>
        public static bool IsSet(this FileAttributes input, FileAttributes matchTo)
        {
            return (input & matchTo) == matchTo;
        }

        /// <summary>
        /// Validates the selected paths
        /// </summary>
        /// <returns>Returns a bool value</returns>
        public static bool Validate(
            string folderPath,
            string iconPath)
        {
            bool valid = false;

            if (AreRootsSame(folderPath, iconPath))
            {
                if (Directory.Exists(folderPath) && File.Exists(iconPath))
                {
                    valid = true;
                }
            }
            return valid;
        }
    }
}
