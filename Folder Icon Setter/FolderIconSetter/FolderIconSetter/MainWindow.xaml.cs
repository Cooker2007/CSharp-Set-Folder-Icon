using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;


namespace FolderIconSetter
{
    using System.Windows.Forms;

    using Application = System.Windows.Application;
    using KeyEventArgs = System.Windows.Input.KeyEventArgs;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Program newProgram = new Program();

        public MainWindow()
        {
            InitializeComponent();
           
        }


        // Buttons
        private void DisplayFolderPathButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayFolderTextBox.Text = newProgram.selection.FolderSelect();
            CustomDriveNameTextBox.IsEnabled = OutputProcessing.IsDisplayFolderRoot(newProgram.selection.DisplayFolderDirectory);
            
            if (!String.IsNullOrWhiteSpace(SelectIconFileTextBox.Text))
            {
                this.IconPathRootError();
            }
        }

        private void IconFileButton_Click(object sender, RoutedEventArgs e)
        {
            SelectIconFileTextBox.Text = newProgram.selection.FileSelect() + newProgram.selection.IconFileName;
        }
        
        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            newProgram.Execute();
        }

        private void MenuFileClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuHelpHelp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuHelpAbout_Click(object sender, RoutedEventArgs e)
        {

        }





        private void CustomDriveNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Prevents the user from entering invalid file name characters
            if (System.IO.Path.GetInvalidFileNameChars().ToString().Contains(e.Key.ToString()))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Changes the background color if the roots are or are not the same
        /// </summary>
        private void IconPathRootError()
        {
            if (!this.newProgram.selection.ComparePathRoots())
            {
               SelectIconFileTextBox.Background = Brushes.Pink;
            }
            else
            {
                SelectIconFileTextBox.ClearValue(BackgroundProperty);
            }
        }

        private void CustomDriveNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newProgram.driveLabel = CustomDriveNameTextBox.Text;
        }



    }
}
