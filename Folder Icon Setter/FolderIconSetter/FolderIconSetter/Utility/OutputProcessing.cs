namespace FolderIconSetter.Utility
{
    using System.IO;

    using FolderIconSetter.Model;

    /// <summary>
    /// The output processing.
    /// </summary>
    internal static class OutputProcessing
    {
        // Validate
        // Folder Attribute
        // File Attribute
        // File Already Exists
        //// Folder does not exist

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="folderPath">
        /// The folder path.
        /// </param>
        /// <param name="iconPath">
        /// The icon path.
        /// </param>
        /// <param name="driveLabel">
        /// The drive label.
        /// </param>
        public static void Execute(SelectedPaths paths)
        {
            
                // Checks if the folder and icon are on same drive
                if (paths.ShareSameRoot)
                {
                    bool overwriteFile = false;
                    bool fileExists = false;

                    // Check if there is already a .ini/.inf file
                    if (CheckFileExists(paths.FolderPath))
                    {
                        // TODO User conformation to overwrite file
                        overwriteFile = true;
                        fileExists = true;
                    }

                    // File does not exist AND/OR can be overridden
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (!fileExists || overwriteFile)
                    {
                        // Set the folder attributes for non-root folders
                        if (!IsDisplayFolderRoot(paths.FolderPath))
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(paths.FolderPath);

                            if (!directoryInfo.Attributes.IsSet(FileAttributes.System))
                            {
                                directoryInfo.Attributes |= FileAttributes.ReadOnly;
                            }
                        }

                        // Text File output
                        // Deletes the file if one exists
                        TextFileOutput.WriteFile(paths);
                    }
                }
            
        }

        /// <summary>
        /// Check if output file exists
        /// </summary>
        /// <param name="folderPath">
        /// The path of the folder to change.
        /// </param>
        /// <returns>
        /// Returns a bool value
        /// </returns>
        public static bool CheckFileExists(string folderPath)
        {
            // Case Insensitive on Windows
            return IsDisplayFolderRoot(folderPath)
                       ? File.Exists(folderPath + "autorun.inf")
                       : File.Exists(folderPath + "desktop.ini");
        }

        /// <summary>
        /// Determines if the Display folder is the root folder
        /// </summary>
        /// <param name="displayFolderDirectory">
        /// The path of the folder to change.
        /// </param>
        /// <returns>
        /// Returns a bool value
        /// </returns>
        public static bool IsDisplayFolderRoot(string displayFolderDirectory)
        {
            return Path.GetPathRoot(displayFolderDirectory).Equals(displayFolderDirectory);
        }

        /// <summary>
        /// Removes "System" allowing the file to be overwritten.
        /// </summary>
        /// <param name="displayFolderDirectory">
        /// The path of the folder to change.
        /// </param>
        public static void RemoveSystemFileAttribute(string displayFolderDirectory)
        {
            if (IsDisplayFolderRoot(displayFolderDirectory))
            {
                displayFolderDirectory += "autorun.inf";
            }
            else
            {
                displayFolderDirectory += "desktop.ini";
            }

            FileInfo fileToChange = new FileInfo(displayFolderDirectory);

            // Bitwise Remove
            fileToChange.Attributes &= ~FileAttributes.System;
        }

        /// <summary>
        /// The remove file attributes.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        public static void RemoveFileAttributes(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            fileInfo.Attributes &= FileAttributes.ReadOnly;
            fileInfo.Attributes &= FileAttributes.System;
            fileInfo.Attributes &= FileAttributes.Hidden;
        }
    }
}