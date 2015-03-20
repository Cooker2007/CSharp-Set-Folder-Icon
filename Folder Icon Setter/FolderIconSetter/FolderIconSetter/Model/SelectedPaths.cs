namespace FolderIconSetter.Model
{
    using System;
    using System.IO;

    using FolderIconSetter.Annotations;

    /// <summary>
    ///     The selected paths.
    /// </summary>
    public class SelectedPaths : ModelBase
    {
        #region Fields

        /// <summary>
        ///     The DriveName backing field.
        /// </summary>
        [NotNull]
        private string driveName;

        /// <summary>
        ///     The FolderPath backing field.
        /// </summary>
        [NotNull]
        private string folderPath;

        /// <summary>
        ///     The IconPath backing field.
        /// </summary>
        [NotNull]
        private string iconPath;

        #endregion Fields

        public SelectedPaths()
        {
            this.driveName = string.Empty;
            this.folderPath = string.Empty;
            this.iconPath = string.Empty;
        }

        #region Properties

        /// <summary>
        ///     Gets or sets the custom drive name.
        /// </summary>
        [NotNull]
        public string DriveName
        {
            get
            {
                return this.driveName;
            }

            set
            {
                if (!this.driveName.Equals(value))
                {
                    this.driveName = value ?? string.Empty;
                    this.RaisePropertyChanged("DriveName");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the path of the folder to change the icon.
        /// </summary>
        [NotNull]
        public string FolderPath
        {
            get
            {
                return this.folderPath;
            }

            set
            {
                if (!this.folderPath.Equals(value))
                {
                    this.folderPath = value ?? string.Empty;
                    this.RaisePropertyChanged("FolderPath");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the icon file path.
        /// </summary>
        [NotNull]
        public string IconPath
        {
            get
            {
                return this.iconPath;
            }

            set
            {
                if (!this.iconPath.Equals(value))
                {
                    this.iconPath = value ?? string.Empty;
                    this.RaisePropertyChanged("IconPath");
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
                    result = fp == this.FolderPath;
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
                if (!string.IsNullOrWhiteSpace(this.FolderPath) && !string.IsNullOrWhiteSpace(this.IconPath))
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
                Uri folder = new Uri(this.FolderPath + "\\file.temp");
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
                if (Directory.Exists(this.folderPath))
                {
                    if (File.Exists(this.iconPath))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}