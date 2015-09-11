namespace MissingFeatures.Tests.DirectoryHelper
{
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Abstractions.TestingHelpers;
    using System.IO.Fakes;
    using System.Linq;

    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /* Test cases:
        - src doesn't exits
        - destination doesn't exits
        - src without subdirectories
        - src with subdirectories
        - src with files
        - src with files in subdirectories
        - recursive = false
        - src == destination
        - ...
    */

    [TestClass]
    public class CopyTests
    {
        [TestMethod]
        public void Test()
        {
            
            var fileSystemData = new Dictionary<string, MockFileData>
            {
                [@"c:\a\b\test.txt"] = new MockFileData("Text file content"),
                [@"..\test"] = new MockDirectoryData(),
                [@"..\binary.bin"] = new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2, 0xff, 0x00, }),
                [@"c:\existing"] = new MockDirectoryData(),
                [@".\test"] = new MockDirectoryData(),
                [@"d:\data"] = new MockDirectoryData()
            };

            var fileSystem = new MockFileSystem(fileSystemData, @"c:\data");

            using (ShimsContext.Create())
            {
                ShimFile.Behavior = new MockFileShimBehavior(fileSystem);

                File.Create(@"C:\Users\Vladislav\Desktop\test.txt");

                Assert.AreEqual(3, fileSystem.AllFiles.Count());
            }
        }
    }
}
