using System;
using System.IO;

namespace FolderIconSetter
{
    

   static class TextFileOutput
    {
        /// <summary>
        /// Writes the text file needed to display the Icon. I can only handle single image .ico files.
        /// </summary>
        /// <param name="isRoot">Determines if "autorun.inf" or "desktop.ini" is used. </param>
        /// <param name="displayFolderPath"></param>
        /// <param name="iconFullPath"></param>
        /// <param name="displayFolderLabel">Text for the system to display for the hard drive or flash drive name.</param>
        static public void WriteNew(bool isRoot, string displayFolderPath, string iconFullPath, string displayFolderLabel ="")
        {
                if (isRoot)
                {
                    WriteAutorunInf(displayFolderPath, iconFullPath, displayFolderLabel);
                }
                else
                {
                    WriteDesktopIni(displayFolderPath, iconFullPath);
                }
        }




       /// <summary>
       /// Creates the text for the autorun.inf file in the root of drives
       /// </summary>
       /// <param name="displayFolderPath"></param>
       /// <param name="iconFullPath"></param>
       /// <param name="displayFolderLabel"></param>
       private static void WriteAutorunInf(
           string displayFolderPath,
           string iconFullPath,
           string displayFolderLabel)
       {
           String relativePath = PathManipulation.MakeRelativePath(displayFolderPath + "\\autorun.inf", iconFullPath);

           using (StreamWriter outputFile = new StreamWriter(displayFolderPath + "\\autorun.inf"))
           {
               outputFile.WriteLine("[Autorun]");
               outputFile.Write("Icon=\"{0}\"", relativePath);
               
               if (displayFolderLabel != "")
               {
                   outputFile.WriteLine("Label=\"{0}\"", displayFolderLabel);
               }
           }
       }




       /// <summary>
       /// Creates the text for the desktop.ini file for all non-root folders.
       /// </summary>
       /// <param name="displayFolderPath"></param>
       /// <param name="iconFullPath"></param>
       private static void WriteDesktopIni(
           string displayFolderPath,
           string iconFullPath)
       {

           String relativePath = PathManipulation.MakeRelativePath(displayFolderPath + "\\desktop.ini", iconFullPath);

           using (StreamWriter outputFile = new StreamWriter(displayFolderPath + "\\desktop.ini"))
           {
               outputFile.WriteLine("[.ShellClassInfo]");
               // No space between the comma and 0!
               outputFile.Write("IconResource=\"{0}\",0", relativePath);
           }
       }
    }
}
