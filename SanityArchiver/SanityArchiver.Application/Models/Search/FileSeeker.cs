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
        /// <summary>
        /// Executes the recursive, patterned based file search
        /// </summary>
        /// <param name="rootDir">DirectoryInfo object that represents the rootDir directory for the search</param>
        /// <param name="pattern">The wildcard based pattern for the search</param>
        /// <returns>List<FileInfo> object that contains the search results</returns>
        public List<FileInfo> Search(DirectoryInfo rootDir, string pattern)
        {
            var foundedFiles = new List<FileInfo>();
            RecursiveTraversing(rootDir, pattern, foundedFiles);
            return foundedFiles;
        }

       /// <summary>
       /// Recursive search engine
       /// </summary>
       /// <param name="rootDir">Root Directory of the recursive search</param>
       /// <param name="pattern">Filename pattern of the search</param>
       /// <param name="foundedFiles">The list that will be populated with the search results</param>
        private void RecursiveTraversing(DirectoryInfo rootDir, string pattern, List<FileInfo> foundedFiles)
        {
            FileInfo[] files = null;
            try
            {
                files = rootDir.GetFiles(pattern);
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

                foreach (var subDir in rootDir.GetDirectories())
                {
                    RecursiveTraversing(subDir, pattern, foundedFiles);
                }
            }
        }
    }
}