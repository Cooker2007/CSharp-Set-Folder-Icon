namespace FolderIconSetter.Utility
{
    using System;
    using System.IO;
    using System.Windows.Media;

    internal static class OutputProcessing
    {
        // Validate
        // Folder Attribute
        // File Attribute
        // File Already Exists
        // Folder does not exist

        public static void Execute(string folderPath, string iconPath, string driveLabel)
        {
            if (CheckFileExists(folderPath))
            {
                // Checks if the folder and icon are on same drive 
                if (Utilities.Validate(folderPath, iconPath))
                {
                    bool overwriteFile = false;
                    bool fileExists = false;

                    // Check if there is already a .ini/.inf file
                    if (CheckFileExists(folderPath))
                    {
                        //TODO User conformation to overwrite file
                        overwriteFile = true;
                        fileExists = true;
                    }
                    
                    // File does not exist OR can be overridden
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if ( !fileExists || overwriteFile)
                    {

                        // Set the folder attributes for non-root folders
                        if (!IsDisplayFolderRoot(folderPath))
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                            
                            if (!directoryInfo.Attributes.IsSet(FileAttributes.System))
                            {
                                directoryInfo.Attributes |= FileAttributes.ReadOnly;
                            }
                        }

                        // Text File output
                        // Deletes file if one exists
                        if (fileExists)
                        {
                            if (IsDisplayFolderRoot(folderPath))
                            {
                                RemoveFileAttributes(folderPath + "\\autorun.inf");
                            }
                            else
                            {
                                RemoveFileAttributes(folderPath + "\\desktop.ini");
                            }
                        }

                        TextFileOutput.WriteNew(
                                    IsDisplayFolderRoot(folderPath),
                                    folderPath,
                                    iconPath,
                                    driveLabel);
                    }
                }
            }
        }

        /// <summary>
        /// Check if output file exists
        /// </summary>
        /// <param name="displayFolderDirectory"></param>
        /// <returns>Returns a bool value</returns>
        public static bool CheckFileExists(string displayFolderDirectory)
        {
            // Case Insensitive on Windows
            return IsDisplayFolderRoot(displayFolderDirectory)
                         ? File.Exists(displayFolderDirectory + "autorun.inf")
                         : File.Exists(displayFolderDirectory + "desktop.ini");
        }

        /// <summary>
        /// Determines if the Display folder is the root folder
        /// </summary>
        /// <returns>Returns a bool value</returns>
        static public bool IsDisplayFolderRoot(string displayFolderDirectory)
        {
            return Path.GetPathRoot(displayFolderDirectory).Equals(displayFolderDirectory);
        }

        /// <summary>
        /// Removes "System" allowing the file to be overwritten.
        /// </summary>
        /// <param name="displayFolderDirectory"></param>
        public static void RemoveSystemFileAttribute(string displayFolderDirectory)
        {
            // TODO Check if filename is case sensitive
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

        public static void RemoveFileAttributes(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            fileInfo.Attributes &= FileAttributes.ReadOnly;
            fileInfo.Attributes &= FileAttributes.System;
            fileInfo.Attributes &= FileAttributes.Hidden;
        }


    }
}
