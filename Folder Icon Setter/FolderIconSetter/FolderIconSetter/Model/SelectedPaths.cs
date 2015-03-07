namespace FolderIconSetter.Model
{
    using System;
    using System.IO;

    /// <summary>
    ///     The selected paths.
    /// </summary>
    internal class SelectedPaths : ModelBase
    {
        #region Fields

        /// <summary>
        ///     The DriveName backing field.
        /// </summary>
        private string driveName;

        /// <summary>
        ///     The FolderPath backing field.
        /// </summary>
        private string folderPath;

        /// <summary>
        ///     The IconPath backing field.
        /// </summary>
        private string iconPath;

        #endregion Fields

        #region Properties

        /// <summary>
        ///     Gets or sets the custom drive name.
        /// </summary>
        public string DriveName
        {
            get
            {
                return this.driveName ?? (this.driveName = string.Empty);
            }

            set
            {
                if (value != null && !this.driveName.Equals(value))
                {
                    this.driveName = value;
                    this.RaisePropertyChanged("DriveName");
                }
                else
                {
                    this.driveName = string.Empty;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the path of the folder to change the icon.
        /// </summary>
        public string FolderPath
        {
            get
            {
                return this.folderPath ?? (this.folderPath = string.Empty);
            }

            set
            {
                if (value != null && !this.folderPath.Equals(value))
                {
                    this.folderPath = value;
                    this.RaisePropertyChanged("FolderPath");
                }
                else
                {
                    this.folderPath = string.Empty;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the icon path.
        /// </summary>
        public string IconPath
        {
            get
            {
                return this.iconPath ?? (this.iconPath = string.Empty);
            }

            set
            {
                if (value != null && !this.iconPath.Equals(value))
                {
                    this.iconPath = value;
                    this.RaisePropertyChanged("IconPath");
                }
                else
                {
                    this.iconPath = string.Empty;
                }
            }
        }

        /// <summary>
        ///     Gets a value indicating whether the paths share the same root.
        /// </summary>
        public bool IsRoot
        {
            get
            {
                try
                {
                    // If a path is string.Empty an ArgumentException is thrown
                    string fp = Path.GetPathRoot(this.FolderPath);
                    string ip = Path.GetPathRoot(this.IconPath);
                    return fp.Equals(ip);
                }
                catch (ArgumentException e)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets a string representing the relative path of the selected paths.
        /// </summary>
        public string RelativePath
        {
            get
            {
                Uri folder = new Uri(this.FolderPath);
                Uri icon = new Uri(this.IconPath);
                Uri relativeUri = folder.MakeRelativeUri(icon);

                string relativePath = relativeUri.ToString();

                relativePath = relativePath.Replace('/', '\\');
                relativePath = relativePath.Replace("%20", " ");

                return relativePath;
            }
        }

        #endregion Properties
    }
}