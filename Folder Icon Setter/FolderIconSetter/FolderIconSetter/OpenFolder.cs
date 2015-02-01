using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderIconSetter
{
    using System.Windows.Controls;
    using System.Windows.Forms;

    class OpenFolder
    {
        private FolderBrowserDialog displayFolderDialog;

        public string Path { get; set; }


        public OpenFolder()
        {
            this.displayFolderDialog = new FolderBrowserDialog();
            this.displayFolderDialog.Description = "Select Folder for the icon";
            this.displayFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            this.displayFolderDialog.ShowNewFolderButton = true;

            Path = String.Empty;

        }



        /// <summary>
        /// Gets the path of the folder to change its icon
        /// </summary>
        /// <returns>Returns and sets the folder path</returns>
        public string FolderSelect()
        {
            DialogResult result = this.displayFolderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Path = this.displayFolderDialog.SelectedPath;
            }

            return this.displayFolderDialog.SelectedPath;
        }






    }
}
