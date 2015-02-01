using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderIconSetter
{
    using System.IO;
    using System.Windows.Forms;

    public class OpenFile
    {
        private OpenFileDialog iconFileDialog;
        
        public string Name { get; set; }

        public string FilePath{ get; set; }

        public string FullyQualified { get; set; }


        // Constructor
        public OpenFile()
        {
            this.iconFileDialog = new OpenFileDialog();
            this.iconFileDialog.Title = "Select the icon file.";
            this.iconFileDialog.CheckFileExists = true;
            this.iconFileDialog.Filter = "Icon Files (*.ico)|*.ico";
            this.iconFileDialog.CheckFileExists = true;
            this.iconFileDialog.CheckPathExists = true;

            Name = "";
            FullyQualified = "";
            FilePath = "";

        }


        /// <summary>
        /// Opens the File Dialog and sets the Properties
        /// </summary>
        public void SelectIcon()
        {
            DialogResult result = this.iconFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                FullyQualified = iconFileDialog.FileName;
                FilePath = FullyQualified.TrimEnd(Name.ToCharArray());
                Name = iconFileDialog.SafeFileName;
            }
        }






    }
}
