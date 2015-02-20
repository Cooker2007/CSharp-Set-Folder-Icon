namespace FolderIconSetter.ViewModel
{
    using FolderIconSetter.Model;
    using FolderIconSetter.Utility;

    /// <summary>
    /// The view model main.
    /// </summary>
    internal class ViewModelMain : ViewModelBase
    {
        /// <summary>
        /// The paths.
        /// </summary>
        private SelectedPaths paths;

        /// <summary>
        /// The display folder.
        /// </summary>
        private OpenFolder displayFolder;

        /// <summary>
        /// The icon file.
        /// </summary>
        private OpenFile iconFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelMain"/> class.
        /// </summary>
        public ViewModelMain()
        {
            this.paths = new SelectedPaths();
            this.displayFolder = new OpenFolder();
            this.iconFile = new OpenFile(@"Select the icon file.", @"Icon Files (*.ico)|*.ico");

            this.ExecuteCommand = new RelayCommand(Execute, CanExecute);
            this.FolderPathBrowserCommand = new RelayCommand(FolderPathBrowser);
            this.FilePathBrowserCommand = new RelayCommand(FilePathBrowser);
        }

        /// <summary>
        /// Gets or sets the execute command.
        /// </summary>
        public RelayCommand ExecuteCommand { get; set; }

        /// <summary>
        /// Gets or sets the folder path browser command.
        /// </summary>
        public RelayCommand FolderPathBrowserCommand { get; set; }

        /// <summary>
        /// Gets or sets the file path browser command.
        /// </summary>
        public RelayCommand FilePathBrowserCommand { get; set; }
        /// <summary>
        /// Gets or sets the folder path.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the icon path.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the drive name.
        /// </summary>
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

        /// <summary>
        /// The folder path browser.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void FolderPathBrowser(object parameter)
        {
            FolderPath = displayFolder.SelectFolder();
        }

        /// <summary>
        /// The file path browser.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void FilePathBrowser(object parameter)
        {
            iconFile.SelectIcon();
            IconPath = iconFile.FilePath;
        }

        /// <summary>
        /// The can execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return Utilities.Validate(paths.FolderPath, paths.IconPath);
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void Execute(object parameter)
        {
            OutputProcessing.Execute(FolderPath, IconPath, DriveName);
        }
    }
}