using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Threading.Tasks;

namespace SanityArchiver.Application.Models
{
    /// <summary>
    /// Search among the files whit a given directory path and pattern.
    /// The search is recursive in the selected folder.
    /// </summary>
    public static class FileSeeker
    {
        public static FileInfo[] Search(string root, string pattern)
        {
            var directory = new DirectoryInfo(root);
            FileInfo[] files = null;
            try
            {
                files = directory.GetFiles(pattern, SearchOption.AllDirectories);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e);
            }
            return files;
        }
    }
}
