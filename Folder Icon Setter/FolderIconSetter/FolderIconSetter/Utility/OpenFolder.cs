namespace FolderIconSetter.Utility
{
    using System;
    using System.Windows.Forms;

    // TODO Change from a folder browser to a file browser

    /// <summary>
    /// The open folder.
    /// </summary>
    internal class OpenFolder : IDisposable
    {
        //// TODO Change to a file browser

        #region Fields

        /// <summary>
        /// The display folder dialog.
        /// </summary>
        private FolderBrowserDialog displayFolderDialog;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFolder"/> class.
        /// </summary>
        public OpenFolder()
        {
            this.displayFolderDialog = new FolderBrowserDialog();
            this.displayFolderDialog.Description = @"Select Folder for the icon";
            this.displayFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            this.displayFolderDialog.ShowNewFolderButton = true;

            this.Path = string.Empty;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get; set; }

        #endregion Properties

        #region Methods

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

            return this.Path;
        }

        #endregion Methods

        public void Dispose()
        {
            this.displayFolderDialog.Dispose();
        }
    }
}