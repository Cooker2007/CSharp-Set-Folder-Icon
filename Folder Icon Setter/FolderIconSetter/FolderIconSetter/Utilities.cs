using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderIconSetter
{
    using System.IO;

    class Utilities
    {
        /// <summary>
        /// Determines if the selected folders have the same root path
        /// </summary>
        /// <returns>Returns a bool value</returns>
        public bool ComparePathRoots(string path1, string path2)
        {
            bool result = !String.IsNullOrWhiteSpace(path1)
                       && !String.IsNullOrWhiteSpace(path2)
                       && Path.GetPathRoot(path1).Equals(Path.GetPathRoot(path2));

            return result;
        }




    }
}
