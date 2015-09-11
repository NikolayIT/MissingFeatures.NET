namespace MissingFeatures.Tests.DirectoryHelper
{
    using System.Collections.Generic;
    using System.IO.Abstractions.TestingHelpers;
    using System.IO.Fakes;

    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MissingFeatures.Tests.DirectoryHelper.ShimBehaviors;

    /* Test cases:
        - src doesn't exits
        - destination doesn't exits
        - src without subdirectories
        - src with subdirectories
        - src with files
        - src with files in subdirectories
        - recursive = false
        - src == destination
        - exact same src dirs like existing destination directory hierarchy
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
                // TODO: Add shim bahaviors for: Directory, FileInfo, DirectoryInfo classes
                // TODO: Extract shim behaviors registrations to a common method
            }
        }
    }
}
