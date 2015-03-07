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

            this.ExecuteCommand = new RelayCommand(this.Execute, this.CanExecute);
            this.FolderPathBrowserCommand = new RelayCommand(this.FolderPathBrowser);
            this.FilePathBrowserCommand = new RelayCommand(this.FilePathBrowser);
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
                return this.paths.FolderPath;
            }

            set
            {
                this.paths.FolderPath = value;
                this.RaisePropertyChanged("FolderPath");
            }
        }

        /// <summary>
        /// Gets or sets the icon path.
        /// </summary>
        public string IconPath
        {
            get
            {
                return this.paths.IconPath;
            }

            set
            {
                this.paths.IconPath = value;
                this.RaisePropertyChanged("IconPath");
            }
        }

        /// <summary>
        /// Gets or sets the drive name.
        /// </summary>
        public string DriveName
        {
            get
            {
                return this.paths.DriveName;
            }

            set
            {
                this.paths.DriveName = value;
                this.RaisePropertyChanged("DriveName");
            }
        }

        /// <summary>
        /// The folder path browser.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        private void FolderPathBrowser(object parameter)
        {
            this.FolderPath = this.displayFolder.SelectFolder();
        }

        /// <summary>
        /// The file path browser.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        private void FilePathBrowser(object parameter)
        {
            this.iconFile.SelectIcon();
            this.IconPath = this.iconFile.FilePath;
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
        private bool CanExecute(object parameter)
        {
            return Utilities.Validate(this.paths.FolderPath, this.paths.IconPath);
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        private void Execute(object parameter)
        {
            OutputProcessing.Execute(this.FolderPath, this.IconPath, this.DriveName);
        }
    }
}