using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderIconSetter.Model
{
    using System.ComponentModel;

    class SelectedPaths : ModelBase
    {
        private string iconPath;
        
        public string IconPath
        {
            get
            {
                return this.iconPath ?? (this.iconPath = String.Empty);
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

                    iconPath = String.Empty;

                }
            }
        }

        private string folderPath;

        public string FolderPath
        {
            get
            {
                return this.folderPath ?? (this.folderPath = String.Empty);
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
                    folderPath = String.Empty;
                }
            }
        }

        private string driveName;

        public string DriveName
        {
            get
            {
                return this.driveName ?? (this.driveName = String.Empty);
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
                    this.driveName = String.Empty;
                }
            }
        }
    }
}
