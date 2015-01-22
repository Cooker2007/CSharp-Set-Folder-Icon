using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderIconSetter
{
    using System.IO;

    internal static class OutputProcessing
    {
        // Validate
        // Folder Attribute
        // File Attribute
        // File Already Exists
        // Folder does not exist


        /// <summary>
        /// Checks if the directories and the file exist.
        /// </summary>
        /// <returns>Returns a bool value</returns>
        public static bool Validate(
            string IconFullyQualifiedPath,
            string IconDirectoryPath,
            string displayFolderDirectory)
        {
            return Directory.Exists(displayFolderDirectory) && Directory.Exists(IconDirectoryPath)
                   && File.Exists(IconFullyQualifiedPath);
        }

        /// <summary>
        /// Adds the "ReadOnly" attribute to a folder if "System" is not set
        /// </summary>
        /// <param name="displayFolderDirectory"></param>
        public static void SetDisplayFolderReadOnly(String displayFolderDirectory)
        {
            DirectoryInfo folderToChange = new DirectoryInfo(displayFolderDirectory);
            
            if ((folderToChange.Attributes &= FileAttributes.System) == FileAttributes.System)
            {
                folderToChange.Attributes |= FileAttributes.ReadOnly;
            }
        }

        /// <summary>
        /// Set the output text file attributes to "Hidden" and "System"
        /// </summary>
        /// <param name="IconFullyQualifiedPath"></param>
        static public void SetOutputFileAttributes(String IconFullyQualifiedPath)
        {
            FileInfo fileToChange = new FileInfo(IconFullyQualifiedPath);

            fileToChange.Attributes |= FileAttributes.Hidden;
            fileToChange.Attributes |= FileAttributes.System;
        }

        /// <summary>
        /// Check if output file exists
        /// </summary>
        /// <param name="displayFolderDirectory"></param>
        /// <returns>Returns a bool value</returns>
        public static bool CheckFileExists(string displayFolderDirectory)
        {
            // TODO Check if filename is case sensitive
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
            fileToChange.Attributes &= ~FileAttributes.System;
        }

    }
}
