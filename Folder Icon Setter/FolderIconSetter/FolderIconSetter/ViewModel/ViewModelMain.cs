using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderIconSetter.ViewModel
{
    using System.Drawing;
    using System.IO;

    using FolderIconSetter.Model;
    using FolderIconSetter.Utility;

    internal class ViewModelMain : ViewModelBase
    {
        private SelectedPaths paths;

        private OpenFolder displayFolder;

        private OpenFile iconFile;


        public RelayCommand ExecuteCommand { get; set; }
        public RelayCommand FolderPathBrowserCommand { get; set; }
        public RelayCommand FilePathBrowserCommand { get; set; }


        // Constructor
        public ViewModelMain()
        {
            this.paths = new SelectedPaths();
            this.displayFolder = new OpenFolder();
            this.iconFile = new OpenFile();

            
            this.ExecuteCommand = new RelayCommand(Execute, CanExecute);
            this.FolderPathBrowserCommand = new RelayCommand(FolderPathBrowser);
            this.FilePathBrowserCommand = new RelayCommand(FilePathBrowser);
        }

        public string FolderPath
        {
            get
            {
                return paths.FolderPath;
            }
            set
            {
                paths.FolderPath = value;
                RaisePropertyChanged("FolderPath");
            }
        }

        public string IconPath
        {
            get
            {
                return paths.IconPath;
            }
            set
            {
                paths.IconPath = value;
                RaisePropertyChanged("IconPath");
            }
        }

        public string DriveName
        {
            get
            {
                return paths.DriveName;
            }
            set
            {
                paths.DriveName = value;
                RaisePropertyChanged("DriveName");
            }
        }

        public void FolderPathBrowser(object parameter)
        {
           FolderPath = displayFolder.SelectFolder();
        }

        public void FilePathBrowser(object parameter)
        {
           IconPath = iconFile.SelectIcon();
        }

        public bool CanExecute(object parameter)
        {
            return Utilities.Validate(paths.FolderPath, paths.IconPath);
        }

        public void Execute(object parameter)
        {
            OutputProcessing.Execute(FolderPath, IconPath, DriveName);
        }



    }




}

