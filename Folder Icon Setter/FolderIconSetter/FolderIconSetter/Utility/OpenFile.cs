namespace FolderIconSetter.Utility
{
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

            this.Name = "";
            this.FullyQualified = "";
            this.FilePath = "";

        }

        /// <summary>
        /// Opens the File Dialog and sets the Properties
        /// </summary>
        public string SelectIcon()
        {
            DialogResult result = this.iconFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.FullyQualified = this.iconFileDialog.FileName;
                this.FilePath = this.FullyQualified.TrimEnd(this.Name.ToCharArray());
                this.Name = this.iconFileDialog.SafeFileName;
            }
            return FullyQualified;
        }
    }
}
