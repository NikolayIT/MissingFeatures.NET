namespace MissingFeatures.Tests.DirectoryHelper
{
    using System;
    using System.IO;
    using System.IO.Abstractions.TestingHelpers;
    using System.IO.Fakes;
    using System.Linq;
    using System.Text;

    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MissingFeatures;

    [TestClass]
    public class CopyTests
    {
        private MockFileSystem fileSystem;

        [TestInitialize]
        public void InitializeFileSystemData()
        {
            this.fileSystem = new MockFileSystem();
            this.fileSystem.AddDirectory(@"c:\test");
            this.fileSystem.AddFile(@"c:\test\test.txt", new MockFileData("Test text file content"));
            this.fileSystem.AddDirectory(@"c:\test\nested-test");
            this.fileSystem.AddFile(@"c:\test\nested-test\text-file.txt", new MockFileData("Some text with ASCII encoding", Encoding.ASCII));
            this.fileSystem.AddFile(@"c:\test\binary.bin", new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2, 0xff, 0x00, }));
            this.fileSystem.AddDirectory(@"c:\empty-dir");
            this.fileSystem.AddDirectory(@"d:\non-empty-dir\test\nested-test\nested-nested-test");
            this.fileSystem.AddFile(@"d:\non-empty-dir\test\nested-test\test-file.bin", new MockFileData(new byte[] { 0x11, 0x22, 0x33, 0x44, 0xff, 0xbb, 0x00, }));
            this.fileSystem.AddFile(@"c:\a\b\c\test.txt", new MockFileData("Text file content"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNonExistingSource_ShouldThrowException()
        {
            using (ShimsContext.Create())
            {
                this.PrepareFileSystemShims();

                DirectoryHelper.Copy(@"c:\test-non-existing\", @"c:\data\");
            }
        }

        [TestMethod]
        public void TestEmptySourceAndNonExistingDestination_ShouldCreateDestination()
        {
            var directoriesBeforeCopy = this.fileSystem.AllDirectories.Count();

            using (ShimsContext.Create())
            {
                this.PrepareFileSystemShims();

                DirectoryHelper.Copy(@"c:\empty-dir", @"c:\data\");
            }

            Assert.AreEqual(directoriesBeforeCopy + 1, this.fileSystem.AllDirectories.Count(), "Incorrect directories count.");
        }

        [TestMethod]
        public void TestEmptySourceAndExistingDestination_ShouldDoNothing()
        {
            var directoriesBeforeCopy = this.fileSystem.AllDirectories.Count();
            var filesBeforeCopy = this.fileSystem.AllFiles.Count();

            using (ShimsContext.Create())
            {
                this.PrepareFileSystemShims();

                DirectoryHelper.Copy(@"c:\empty-dir", @"c:\a");
            }

            Assert.AreEqual(directoriesBeforeCopy, this.fileSystem.AllDirectories.Count(), "Incorrect directories count.");
            Assert.AreEqual(filesBeforeCopy, this.fileSystem.AllFiles.Count(), "Incorrect files count.");
        }

        [TestMethod]
        public void TestEqualSourceAndDestination_ShouldDoNothing()
        {
            var directoriesBeforeCopy = this.fileSystem.AllDirectories.Count();
            var filesBeforeCopy = this.fileSystem.AllFiles.Count();

            using (ShimsContext.Create())
            {
                this.PrepareFileSystemShims();

                DirectoryHelper.Copy(@"c:\test", @"c:\test");
            }

            Assert.AreEqual(directoriesBeforeCopy, this.fileSystem.AllDirectories.Count(), "Incorrect directories count.");
            Assert.AreEqual(filesBeforeCopy, this.fileSystem.AllFiles.Count(), "Incorrect files count.");
        }

        [TestMethod]
        public void TestNonEmptySourceAndNonExistingDestination_ShouldHaveCorrectDirectoriesCountAndFilesCount()
        {
            var directoriesBeforeCopy = this.fileSystem.AllDirectories.Count();
            var filesBeforeCopy = this.fileSystem.AllFiles.Count();

            using (ShimsContext.Create())
            {
                this.PrepareFileSystemShims();

                DirectoryHelper.Copy(@"c:\a", @"c:\empty-dir2");
            }

            Assert.AreEqual(directoriesBeforeCopy + 3, this.fileSystem.AllDirectories.Count(), "Incorrect directories count.");
            Assert.AreEqual(filesBeforeCopy + 1, this.fileSystem.AllFiles.Count(), "Incorrect files count.");
        }

        [TestMethod]
        public void TestNonEmptySourceAndExistingDestination_ShouldHaveCorrectDirectoriesCountAndFilesCount()
        {
            var directoriesBeforeCopy = this.fileSystem.AllDirectories.Count();
            var filesBeforeCopy = this.fileSystem.AllFiles.Count();

            using (ShimsContext.Create())
            {
                this.PrepareFileSystemShims();

                DirectoryHelper.Copy(@"c:\a", @"c:\empty-dir");
            }

            Assert.AreEqual(directoriesBeforeCopy + 2, this.fileSystem.AllDirectories.Count(), "Incorrect directories count.");
            Assert.AreEqual(filesBeforeCopy + 1, this.fileSystem.AllFiles.Count(), "Incorrect files count.");
        }

        [TestMethod]
        public void TestNonEmptySourceWithoutFilesAndExistingDestinationNonRecursive_ShouldHaveCorrectDirectoriesCountAndFilesCount()
        {
            var directoriesBeforeCopy = this.fileSystem.AllDirectories.Count();
            var filesBeforeCopy = this.fileSystem.AllFiles.Count();

            using (ShimsContext.Create())
            {
                this.PrepareFileSystemShims();

                DirectoryHelper.Copy(@"c:\a", @"c:\empty-dir", false, false);
            }

            Assert.AreEqual(directoriesBeforeCopy + 1, this.fileSystem.AllDirectories.Count(), "Incorrect directories count.");
            Assert.AreEqual(filesBeforeCopy, this.fileSystem.AllFiles.Count(), "Incorrect files count.");
        }

        [TestMethod]
        public void TestNonEmptySourceWithFilesAndExistingDestinationNonRecursive_ShouldHaveCorrectDirectoriesCountAndFilesCount()
        {
            var directoriesBeforeCopy = this.fileSystem.AllDirectories.Count();
            var filesBeforeCopy = this.fileSystem.AllFiles.Count();

            using (ShimsContext.Create())
            {
                this.PrepareFileSystemShims();

                DirectoryHelper.Copy(@"c:\test", @"c:\empty-dir", false, false);
            }

            Assert.AreEqual(directoriesBeforeCopy + 1, this.fileSystem.AllDirectories.Count(), "Incorrect directories count.");
            Assert.AreEqual(filesBeforeCopy + 2, this.fileSystem.AllFiles.Count(), "Incorrect files count.");
        }

        [TestMethod]
        public void TestNonEmptySourceAndDestinationWithoutFileOverwrite_ShouldHaveCorrectFileContent()
        {
            const string DestinationTestFilePath = @"c:\a\b\c\test.txt";

            var destinationTestFileContentBeforeCopy = this.fileSystem.GetFile(DestinationTestFilePath).TextContents;

            using (ShimsContext.Create())
            {
                this.PrepareFileSystemShims();

                DirectoryHelper.Copy(@"c:\test", @"c:\a\b\c\");
            }

            var destinationTestFileContentAfterCopy = this.fileSystem.GetFile(DestinationTestFilePath).TextContents;
            Assert.AreEqual(destinationTestFileContentBeforeCopy, destinationTestFileContentAfterCopy, "Invalid file content.");
        }

        [TestMethod]
        public void TestNonEmptySourceAndDestinationWithFileOverwrite_ShouldHaveCorrectFileContent()
        {
            const string SourceTestFilePath = @"c:\test\test.txt";
            const string DestinationTestFilePath = @"c:\a\b\c\test.txt";

            var sourceTestFileContentBeforeCopy = this.fileSystem.GetFile(SourceTestFilePath).TextContents;

            using (ShimsContext.Create())
            {
                this.PrepareFileSystemShims();

                DirectoryHelper.Copy(@"c:\test", @"c:\a\b\c\", true);
            }

            var destinationTestFileContentAfterCopy = this.fileSystem.GetFile(DestinationTestFilePath).TextContents;
            Assert.AreEqual(sourceTestFileContentBeforeCopy, destinationTestFileContentAfterCopy, "Invalid file content.");
        }

        [TestMethod]
        public void TestSimilarSourceAndDestinationDirectoryHierarchies_ShouldHaveCorrectDirectoriesCountAndFilesCount()
        {
            var directoriesBeforeCopy = this.fileSystem.AllDirectories.Count();
            var filesBeforeCopy = this.fileSystem.AllFiles.Count();

            using (ShimsContext.Create())
            {
                this.PrepareFileSystemShims();

                DirectoryHelper.Copy(@"c:\", @"d:\non-empty-dir\");
            }

            Assert.AreEqual(directoriesBeforeCopy + 4, this.fileSystem.AllDirectories.Count(), "Incorrect directories count.");
            Assert.AreEqual(filesBeforeCopy + 4, this.fileSystem.AllFiles.Count(), "Incorrect files count.");
        }

        private void PrepareFileSystemShims()
        {
            ShimDirectory.ExistsString = dirPath => this.fileSystem.Directory.Exists(dirPath);
            ShimDirectory.CreateDirectoryString = dirPath =>
            {
                this.fileSystem.AddDirectory(dirPath);
                return new DirectoryInfo(dirPath);
            };

            ShimFile.ExistsString = filePath => this.fileSystem.File.Exists(filePath);
            ShimFile.CopyStringStringBoolean =
                (sourceFilePath, destinationFilePath, overwrite) => this.fileSystem.File.Copy(sourceFilePath, destinationFilePath, overwrite);

            ShimDirectoryInfo.AllInstances.ExistsGet = dir => this.fileSystem.DirectoryInfo.FromDirectoryName(dir.FullName).Exists;
            ShimDirectoryInfo.AllInstances.GetFiles =
                dir => this.fileSystem.Directory.GetFiles(dir.FullName).Select(filePath => new FileInfo(filePath)).ToArray();
            ShimDirectoryInfo.AllInstances.GetDirectories =
                dir => this.fileSystem.Directory.GetDirectories(dir.FullName).Select(dirPath => new DirectoryInfo(dirPath)).ToArray();
        }
    }
}
