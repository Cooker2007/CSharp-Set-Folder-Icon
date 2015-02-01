using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderIconSetter
{
    using System.IO;
    using System.Windows.Media.Animation;

    public class FileFolderSelection
    {
        private FolderBrowserDialog displayFolderDialog;

        private OpenFileDialog iconFileDialog;

        public string DisplayFolderDirectory { get; private set; }

        public string IconFullyQualifiedPath { get; private set; }

        public string IconDirectoryPath
        {
            get { return this.IconFullyQualifiedPath.TrimEnd(Path.GetFileName(this.IconFullyQualifiedPath).ToCharArray()); }
        }

        public string IconFileName
        {
            get { return Path.GetFileName(this.IconFullyQualifiedPath); }
        }
        


        // Constructor
        public FileFolderSelection()
        {
            this.iconFileDialog = new OpenFileDialog();
            this.iconFileDialog.Title = "Select the icon file.";
            this.iconFileDialog.CheckFileExists = true;
            this.iconFileDialog.Filter = "Icon Files (*.ico)|*.ico";
           
            this.displayFolderDialog = new FolderBrowserDialog();
            this.displayFolderDialog.Description = @"Select Folder...";
            
            //TODO Test if this needed
            //this.DisplayFolderDirectory = "C:\\";
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
                    this.DisplayFolderDirectory = this.displayFolderDialog.SelectedPath;
            }
            return this.displayFolderDialog.SelectedPath;
        }

        /// <summary>
        /// Gets the full file path of the icon file
        /// </summary>
        /// <returns>Returns and sets the full file path</returns>
        public string FileSelect()
        {
            DialogResult result = this.iconFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.IconFullyQualifiedPath = Path.GetFullPath(this.iconFileDialog.FileName);
            }
            return this.IconDirectoryPath;
        }








    }
}
