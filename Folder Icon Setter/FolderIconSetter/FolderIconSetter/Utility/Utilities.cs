// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utilities.cs" company="">
//
// </copyright>
// <summary>
//   The utilities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FolderIconSetter.Utility
{
    using System;
    using System.IO;

    /// <summary>
    /// The utilities.
    /// </summary>
    internal static class Utilities
    {
        /// <summary>
        /// Determines if the selected folders have the same root path
        /// </summary>
        /// <param name="path1">
        /// The path 1.
        /// </param>
        /// <param name="path2">
        /// The path 2.
        /// </param>
        /// <returns>
        /// Returns a bool value
        /// </returns>
        public static bool AreRootsSame(string path1, string path2)
        {
            bool result = !string.IsNullOrWhiteSpace(path1) && !string.IsNullOrWhiteSpace(path2)
                          && Path.GetPathRoot(path1).Equals(Path.GetPathRoot(path2));

            return result;
        }

        /// <summary>
        /// The make relative path.
        /// </summary>
        /// <param name="sourcePath">
        /// The source path.
        /// </param>
        /// <param name="destinationPath">
        /// The destination path.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
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
        /// <param name="input">
        /// </param>
        /// <param name="matchTo">
        /// </param>
        /// <returns>
        /// Returns bool, true if contains Attribute
        /// </returns>
        public static bool IsSet(this FileAttributes input, FileAttributes matchTo)
        {
            return (input & matchTo) == matchTo;
        }

        /// <summary>
        /// Validates the selected paths
        /// </summary>
        /// <param name="folderPath">
        /// The folder Path.
        /// </param>
        /// <param name="iconPath">
        /// The icon Path.
        /// </param>
        /// <returns>
        /// Returns a bool value
        /// </returns>
        public static bool Validate(string folderPath, string iconPath)
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