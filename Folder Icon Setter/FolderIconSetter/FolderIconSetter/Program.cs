﻿using System;
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
            if (OutputProcessing.Validate(this.selection.IconFullyQualifiedPath, this.selection.IconDirectoryPath, this.selection.DisplayFolderDirectory))
            {

                //TODO Check if text file exists
                    //TODO ask user for confirmation
                        //TODO process existing file

                if (!OutputProcessing.IsDisplayFolderRoot(selection.DisplayFolderDirectory))
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