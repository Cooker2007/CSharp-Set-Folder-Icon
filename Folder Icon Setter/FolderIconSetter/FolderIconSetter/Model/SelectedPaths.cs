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

        public SelectedPaths()
        {
            driveName = string.Empty;
            folderPath = string.Empty;
            iconPath = string.Empty;
        }

        #region Properties

        /// <summary>
        ///     Gets or sets the custom drive name.
        /// </summary>
        public string DriveName
        {
            get
            {
                return this.driveName ?? (this.driveName = String.Empty);
            }

            set
            {
                if (value != null && !this.driveName.Equals(value))
                {
                    this.driveName = value;
                    this.RaisePropertyChanged("DriveName");
                }
                else if (value == null)
                {
                    this.driveName = String.Empty;
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
                return this.folderPath ?? (this.folderPath = String.Empty);
            }

            set
            {
                if (value != null && !this.folderPath.Equals(value))
                {
                    this.folderPath = value;
                    this.RaisePropertyChanged("FolderPath");
                }
                else if (value == null)
                {
                    this.folderPath = String.Empty;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the icon file path.
        /// </summary>
        public string IconPath
        {
            get
            {
                return this.iconPath ?? (this.iconPath = String.Empty);
            }

            set
            {
                if (value != null && !this.iconPath.Equals(value))
                {
                    this.iconPath = value;
                    this.RaisePropertyChanged("IconPath");
                }
                else if (value == null)
                {
                    this.iconPath = String.Empty;
                }
            }
        }

        public bool IsFolderPathRoot
        {
            get
            {
                bool result = false;
                if (!string.IsNullOrWhiteSpace(this.FolderPath))
                {
                    string fp = Path.GetPathRoot(this.FolderPath);
                    result = fp == FolderPath;
                }
                return result;

            }
        }

        /// <summary>
        ///     Gets a value indicating whether the paths share the same root.
        /// </summary>
        public bool ShareSameRoot
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(FolderPath) || !string.IsNullOrWhiteSpace(IconPath))
                {
                    // If a path is string.Empty an ArgumentException is thrown
                    string fp = Path.GetPathRoot(this.FolderPath);
                    string ip = Path.GetPathRoot(this.IconPath);
                    return fp.Equals(ip);
                }
                return false;
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

        /// <summary>
        /// Validates the selected paths
        /// </summary>
        public bool Validate()
        {
            if (this.ShareSameRoot)
            {
                if (Directory.Exists(folderPath))
                {
                    if (File.Exists(iconPath))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}