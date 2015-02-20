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
    /// <summary>
    /// The selected paths.
    /// </summary>
    internal class SelectedPaths : ModelBase
    {
        /// <summary>
        /// The icon path.
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
                if (value != null)
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
        /// The folder path.
        /// </summary>
        private string folderPath;

        /// <summary>
        /// Gets or sets the folder path.
        /// </summary>
        public string FolderPath
        {
            get
            {
                return this.folderPath ?? (this.folderPath = string.Empty);
            }

            set
            {
                if (value != null)
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
        /// The drive name.
        /// </summary>
        private string driveName;

        /// <summary>
        /// Gets or sets the drive name.
        /// </summary>
        public string DriveName
        {
            get
            {
                return this.driveName ?? (this.driveName = string.Empty);
            }

            set
            {
                if (value != null)
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
    }
}