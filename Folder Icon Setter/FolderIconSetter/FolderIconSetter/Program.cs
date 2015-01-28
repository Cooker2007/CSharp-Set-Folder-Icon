using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderIconSetter
{
    using System.IO;
    using System.Windows.Forms;

    class Program
    {
        public FileFolderSelection selection;

        public string driveLabel;

        // Constructor
        public Program()
        {
            this.selection = new FileFolderSelection();
        }

        public void Execute()
        {
            if (OutputProcessing.Validate(
                this.selection.IconFullyQualifiedPath,
                this.selection.IconDirectoryPath,
                this.selection.DisplayFolderDirectory))
            {
                if (OutputProcessing.CheckFileExists(selection.DisplayFolderDirectory))
                {
                    

                    //TODO Check if text file exists
                    //TODO ask user for confirmation
                    //TODO process existing file

                    // Sets "ReadOnly" for non root and non "System" folders.
                    if (!OutputProcessing.IsDisplayFolderRoot(selection.DisplayFolderDirectory)
                        && !OutputProcessing.IsFolderSystem(selection.DisplayFolderDirectory))
                    {
                        OutputProcessing.SetDisplayFolderReadOnly(this.selection.DisplayFolderDirectory);
                    }

                    TextFileOutput.WriteNew(
                        OutputProcessing.IsDisplayFolderRoot(selection.DisplayFolderDirectory),
                        this.selection.DisplayFolderDirectory,
                        this.selection.IconFullyQualifiedPath,
                        driveLabel);
                }
            }
        }
    }
}
