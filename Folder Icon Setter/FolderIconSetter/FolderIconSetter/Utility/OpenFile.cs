namespace FolderIconSetter.Utility
{
    using System.Windows.Forms;
    using FolderIconSetter.Annotations;
    
    /// <summary>
    /// Wrapper class for OpenFileDialog.
    /// </summary>
    public class OpenFile
    {
        /// <summary>
        /// The open file dialog for selecting the icon.
        /// </summary>
        [NotNull]
        private readonly OpenFileDialog iconFileDialog;

        /// <summary>
        /// The file name.
        /// </summary>
        private string name;

        /// <summary>
        /// The file path.
        /// </summary>
        private string filePath;

        /// <summary>
        /// The fully qualified file path.
        /// </summary>
        private string fullyQualified;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFile"/> class.
        /// </summary>
        /// <param name="title">
        /// The title of the dialog.
        /// </param>
        /// <param name="filter">
        /// The filter for the desired file types.
        /// </param>
        public OpenFile(string title = "Select...", string filter = "")
        {
            this.iconFileDialog = new OpenFileDialog
                                      {
                                          Title = title,
                                          CheckFileExists = true,
                                          Filter = filter
                                      };
            this.iconFileDialog.CheckFileExists = true;
            this.iconFileDialog.CheckPathExists = true;

            this.Name = string.Empty;
            this.FullyQualified = string.Empty;
            this.FilePath = string.Empty;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name ?? (this.name = string.Empty);
            }

            set
            {
                this.name = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        public string FilePath
        {
            get
            {
                return this.filePath ?? (this.filePath = string.Empty);
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.filePath = string.Empty;
                }

                this.filePath = value;
            }
        }

        /// <summary>
        /// Gets or sets the fully qualified.
        /// </summary>
        public string FullyQualified
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.fullyQualified))
                {
                    this.fullyQualified = string.Empty;
                }

                return this.fullyQualified;
            }

            set
            {
                this.fullyQualified = value;
            }
        }

        /// <summary>
        /// Opens the File Dialog and sets the Properties
        /// </summary>
        public void SelectIcon()
        {
            DialogResult result = this.iconFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.FullyQualified = this.iconFileDialog.FileName;
                this.Name = this.iconFileDialog.SafeFileName;
                this.FilePath = this.FullyQualified.TrimEnd(this.Name.ToCharArray());
            }
        }
    }
}