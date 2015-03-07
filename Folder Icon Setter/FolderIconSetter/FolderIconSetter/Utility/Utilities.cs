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