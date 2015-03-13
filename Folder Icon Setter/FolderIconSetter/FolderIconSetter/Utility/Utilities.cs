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
    }
}