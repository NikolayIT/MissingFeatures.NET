namespace MissingFeatures
{
    using System;
    using System.IO;

    public static class DirectoryHelper
    {
        public static void Copy(string sourceDirectoryPath, string destinationDirectoryPath, bool overwriteFiles = false, bool recursive = true)
        {
            var sourceDirectory = new DirectoryInfo(sourceDirectoryPath);
            if (!sourceDirectory.Exists)
            {
                throw new ArgumentException("Source directory not found on file system.", nameof(sourceDirectoryPath));
            }

            if (!Directory.Exists(destinationDirectoryPath))
            {
                Directory.CreateDirectory(destinationDirectoryPath);
            }

            // TODO: Check if the src == destination dir
            var files = sourceDirectory.GetFiles();
            foreach (var file in files)
            {
                var newFilePath = Path.Combine(destinationDirectoryPath, file.Name);
                if (overwriteFiles || !File.Exists(newFilePath))
                {
                    File.Copy(file.FullName, newFilePath, overwriteFiles);
                }
            }

            if (recursive)
            {
                var subDirectories = sourceDirectory.GetDirectories();
                foreach (var directory in subDirectories)
                {
                    var newDirectoryPath = Path.Combine(destinationDirectoryPath, directory.Name);
                    Copy(directory.FullName, newDirectoryPath, overwriteFiles);
                }
            }
        }
    }
}
