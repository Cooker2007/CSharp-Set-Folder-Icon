// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectedPaths.cs" company="">
//
// </copyright>
// <summary>
//   The selected paths.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FolderIconSetter.Model
{
    using System;
    using System.IO;

    /// <summary>
    /// The selected paths.
    /// </summary>
    internal class SelectedPaths : ModelBase
    {
        /// <summary>
        /// The IconPath backing field.
        /// </summary>
        private string iconPath;

        /// <summary>
        /// Gets or sets the icon path.
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
                    RaisePropertyChanged("IconPath");
                }
                else
                {
                    iconPath = string.Empty;
                }
            }
        }

        /// <summary>
        /// The FolderPath backing field.
        /// </summary>
        private string folderPath;

        /// <summary>
        /// Gets or sets the path of the folder to change the icon.
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
                    RaisePropertyChanged("FolderPath");
                }
                else
                {
                    folderPath = string.Empty;
                }
            }
        }

        /// <summary>
        /// The DriveName backing field.
        /// </summary>
        private string driveName;

        /// <summary>
        /// Gets or sets the custom drive name.
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
                    RaisePropertyChanged("DriveName");
                }
                else
                {
                    this.driveName = string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets a bool if the paths are on the same root drive.
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
    }
}