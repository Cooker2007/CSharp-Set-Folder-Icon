using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderIconSetter.Model
{
    using System.ComponentModel;

    class SelectedPaths : INotifyPropertyChanged
    {
        private string iconPath;
        public 

        public string IconPath
        {
            get
            {
                return this.iconPath;
            }
            set
            {
                if (iconPath == null)
                {
                    iconPath = String.Empty;
                }
                else
                {
                    this.iconPath = value;
                }
            }
        }

        private string folderPath;



        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
