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

            var destinationDirectoryFullPath = Path.GetFullPath(destinationDirectoryPath);
            if (destinationDirectoryFullPath != sourceDirectory.FullName)
            {
                Directory.CreateDirectory(destinationDirectoryFullPath);

                var files = sourceDirectory.GetFiles();
                foreach (var file in files)
                {
                    var newFilePath = Path.Combine(destinationDirectoryFullPath, file.Name);
                    if (overwriteFiles || !File.Exists(newFilePath))
                    {
                        File.Copy(file.FullName, newFilePath, overwriteFiles);
                    }
                }

                var subDirectories = sourceDirectory.GetDirectories();
                foreach (var directory in subDirectories)
                {
                    var newDirectoryPath = Path.Combine(destinationDirectoryFullPath, directory.Name);
                    if (recursive)
                    {
                        Copy(directory.FullName, newDirectoryPath, overwriteFiles);
                    }
                    else
                    {
                        Directory.CreateDirectory(newDirectoryPath);
                    }
                }
            }
        }
    }
}
