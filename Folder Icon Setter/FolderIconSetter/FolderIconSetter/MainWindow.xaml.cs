namespace FolderIconSetter
{
    using System.Windows;
    
    /// <summary>
    /// The main window.
    /// </summary>
    public partial class MainWindow : Window
    {
        // private Program newProgram = new Program();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        //// Buttons
        // private void DisplayFolderPathButton_Click(object sender, RoutedEventArgs e)
        // {
        // DisplayFolderTextBox.Text = newProgram.selection.SelectFolder();
        // CustomDriveNameTextBox.IsEnabled = OutputProcessing.IsDisplayFolderRoot(newProgram.selection.DisplayFolderDirectory);

        // if (!string.IsNullOrWhiteSpace(SelectIconFileTextBox.Text))
        // {
        // this.IconPathRootError();
        // }
        // }

        // private void IconFileButton_Click(object sender, RoutedEventArgs e)
        // {
        // SelectIconFileTextBox.Text = newProgram.selection.FileSelect() + newProgram.selection.IconFileName;
        // }

        // private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        // {
        // newProgram.Execute();
        // }

        // private void MenuFileClose_Click(object sender, RoutedEventArgs e)
        // {
        // Application.Current.Shutdown();
        // }

        // private void MenuHelpHelp_Click(object sender, RoutedEventArgs e)
        // {
        // }

        // private void MenuHelpAbout_Click(object sender, RoutedEventArgs e)
        // {
        // }

        // private void CustomDriveNameTextBox_KeyDown(object sender, KeyEventArgs e)
        // {
        // // Prevents the user from entering invalid file name characters
        // if (System.IO.Path.GetInvalidFileNameChars().ToString().Contains(e.Key.ToString()))
        // {
        // e.Handled = true;
        // }
        // }

        ///// <summary>
        ///// Changes the background color if the roots are or are not the same
        ///// </summary>
        // private void IconPathRootError()
        // {
        // //if (!this.newProgram.selection.ComparePathRoots())
        // //{
        // //   SelectIconFileTextBox.Background = Brushes.Pink;
        // //}
        // //else
        // //{
        // //    SelectIconFileTextBox.ClearValue(BackgroundProperty);
        // //}
        // }

        // private void CustomDriveNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        // {
        // newProgram.driveLabel = CustomDriveNameTextBox.Text;
        // }
    }
}