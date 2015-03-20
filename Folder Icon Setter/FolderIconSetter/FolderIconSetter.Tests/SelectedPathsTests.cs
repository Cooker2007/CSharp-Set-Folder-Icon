namespace FolderIconSetter.Tests.Unit
{
    using NUnit.Framework;
    using FolderIconSetter.Model;

    [TestFixture]
    public class SelectedPathsTests
    {
        // ToDo Test the RaisePropertyChanged events

        [Test]
        public void IsFolderPathRoot_IsRoot_ReturnsTrue()
        {
            // Arrange
            var sut = CreateSelectedPaths();
            sut.FolderPath = "C:\\";
            
            // Act
            bool result = sut.IsFolderPathRoot;

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase("C:\\folder", false)]
        [TestCase("E:\\folder\\folder", false)]
        [TestCase("", false)]
        [TestCase("   ", false)]
        [TestCase("------", false)]
        public void IsFolderPathRoot_VariousNonRootPaths_ReturnsFalse(string path, bool expected)
        {
            // Arrange
            var sut = CreateSelectedPaths();
            sut.FolderPath = path;
            
            // Act
            bool result = sut.IsFolderPathRoot;

            // Assert
            Assert.AreEqual(expected,result);
        }

        [TestCase("C:\\","C:\\icon.ico",true)]
        [TestCase("C:\\","C:\\folder\\icon.ico",true)]
        [TestCase("C:\\", "D:\\icon.ico", false)]
        [TestCase("C\\", "D:\\folder\\icon.ico", false)]
        [TestCase("C:\\", "", false)]
        [TestCase("", "C:\\icon.ico", false)]
        [TestCase("", "", false)]
        public void ShareSameRoot_VariousPaths_ChecksThem(string folder, string icon, bool expected)
        {
            // Arrange
            var sut = CreateSelectedPaths();
            sut.FolderPath = folder;
            sut.IconPath = icon;

            // Act
            bool result = sut.ShareSameRoot;

            // Assert
            Assert.AreEqual(expected,result);
        }

        [TestCase("C:\\", "C:\\icon.ico", "..\\icon.ico")]
        [TestCase("C:\\", "C:\\icon with spaces.ico", "..\\icon with spaces.ico")]
        [TestCase("C:\\", "C:\\folder with spaces\\icon.ico", "..\\folder with spaces\\icon.ico")]
        [TestCase("C:\\", "C:\\folder\\icon with spaces.ico", "..\\folder\\icon with spaces.ico")]
        public void ReletivePath_GivenNonNestedFolderPaths_ReturnsCorrectPath(string folder, string icon, string expected)
        {
            // Arrange
            var sut = CreateSelectedPaths();
            sut.FolderPath = folder;
            sut.IconPath = icon;

            // Act
            string result = sut.RelativePath;

            // Assert
            StringAssert.AreEqualIgnoringCase(expected, result);
        }


        [TestCase("C:\\a", "C:\\icon.ico", "..\\icon.ico")]
        [TestCase("C:\\a\\a", "C:\\icon.ico", "..\\..\\icon.ico")]
        [TestCase("C:\\a\\a\\a\\a\\a", "C:\\icon.ico", "..\\..\\..\\..\\..\\icon.ico")]
        public void ReletivePath_GivenNestedFolderPaths_ReturnsCorrectPath(string folder, string icon, string expected)
        {
            // Arrange
            var sut = CreateSelectedPaths();
            sut.FolderPath = folder;
            sut.IconPath = icon;

            // Act
            string result = sut.RelativePath;

            // Assert
            StringAssert.AreEqualIgnoringCase(expected, result);
        }

        [TestCase("C:\\a", "C:\\b\\icon.ico", "..\\b\\icon.ico")]
        public void ReletivePath_GivenNestedFolderAndNestedIconPaths_ReturnsCorrectPath(string folder, string icon, string expected)
        {
            // Arrange
            var sut = CreateSelectedPaths();
            sut.FolderPath = folder;
            sut.IconPath = icon;

            // Act
            string result = sut.RelativePath;

            // Assert
            StringAssert.AreEqualIgnoringCase(expected, result);
        }

        private SelectedPaths CreateSelectedPaths(string type = "")
        {
            SelectedPaths selectedPaths;
            if (type == "populated")
            {
                selectedPaths = new SelectedPaths()
                                    {
                                        FolderPath = "C:\\",
                                        IconPath = "C:\\icon.ico",
                                        DriveName = "DriveName"
                                    };
            }
            selectedPaths = new SelectedPaths();
            
            return selectedPaths;
        }
    }
}
