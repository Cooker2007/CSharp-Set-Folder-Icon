using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderIconSetter
{
    using System.IO;

    internal static class PathManipulation
    {
        public static string MakeRelativePath(string displayFolderPath, string iconSaveFilePath)
        {
            string relativePath = "";
           
            if (Directory.Exists(displayFolderPath.TrimEnd(Path.GetFileName(displayFolderPath).ToCharArray())))
            {
                if (File.Exists(iconSaveFilePath))
                {
                    if (Path.GetPathRoot(displayFolderPath).Equals(Path.GetPathRoot(iconSaveFilePath)))
                    {

                        Uri uri = new Uri(displayFolderPath);
                        relativePath = uri.MakeRelativeUri(new Uri(iconSaveFilePath)).ToString();
                        relativePath = relativePath.Replace('/', '\\');
                        relativePath = relativePath.Replace("%20", " ");

                    }
                }
               
            }
            return relativePath;
        }
    }
}

