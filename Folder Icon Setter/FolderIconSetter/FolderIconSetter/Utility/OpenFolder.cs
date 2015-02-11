namespace FolderIconSetter.Utility
{
    using System;
    using System.Windows.Forms;

    //TODO Change from a folder browser to a file browser
    class OpenFolder
    {

        //TODO Change to a file browser
        private FolderBrowserDialog displayFolderDialog;

        public string Path { get; set; }


        public OpenFolder()
        {
            this.displayFolderDialog = new FolderBrowserDialog();
            this.displayFolderDialog.Description = "Select Folder for the icon";
            this.displayFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            this.displayFolderDialog.ShowNewFolderButton = true;
            
            this.Path = String.Empty;

        }



        /// <summary>
        /// Gets the path of the folder to change its icon
        /// </summary>
        /// <returns>Returns and sets the folder path</returns>
        public string SelectFolder()
        {
            DialogResult result = this.displayFolderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Path = this.displayFolderDialog.SelectedPath;
            }

            return Path;
        }






    }
}
