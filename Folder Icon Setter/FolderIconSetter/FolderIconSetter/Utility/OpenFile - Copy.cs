
namespace FolderIconSetter.Utility
{
    using System.Windows.Forms;

    using FolderIconSetter.Annotations;

    /// <summary>
    /// The open file.
    /// </summary>
    public class OpenFileTesting
    {
        private readonly string title;

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
        public OpenFileTesting(string title = "", string filter = "")
        {
            this.title = title;
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
        [NotNull]
        public string Name
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.name) ? string.Empty : this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        [NotNull]
        public string FilePath
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.filePath) ? string.Empty : this.filePath;
            }

            set
            {
                this.filePath = value;
            }
        }

        /// <summary>
        /// Gets or sets the fully qualified.
        /// </summary>
        [NotNull]
        public string FullyQualified
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.fullyQualified) ? string.Empty : this.fullyQualified;
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