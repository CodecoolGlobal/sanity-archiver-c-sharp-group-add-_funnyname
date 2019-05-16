using System;
using System.Collections.Generic;
using System.IO;

namespace SanityArchiver.Application.Models.Search
{
    /// <summary>
    /// Search among the files whit a given directory path and pattern.
    /// The search is recursive in the selected folder.
    /// </summary>
    public class FileSeeker
    {
        /// <inheritdoc/>
        public List<FileInfo> Search(string filePath, string fileName)
        {
            var directory = new DirectoryInfo(filePath);
            var foundedFiles = SearchFile(directory, fileName);
            return foundedFiles;
        }

        /// <inheritdoc/>
        private List<FileInfo> SearchFile(DirectoryInfo rootDir, string fileName)
        {
            var foundedFiles = new List<FileInfo>();
            RecursiveTraversing(rootDir, fileName, foundedFiles);
            return foundedFiles;
        }

        /// <inheritdoc/>
        private void RecursiveTraversing(DirectoryInfo directoryInfo, string fileName, List<FileInfo> foundedFiles)
        {
            FileInfo[] files = null;
            try
            {
                files = directoryInfo.GetFiles(fileName);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
            }

            if (files != null)
            {
                foreach (var fileInfo in files)
                {
                    foundedFiles.Add(fileInfo);
                }

                foreach (var subDir in directoryInfo.GetDirectories())
                {
                    RecursiveTraversing(subDir, fileName, foundedFiles);
                }
            }
        }
    }
}