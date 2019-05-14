using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SanityArchiver.Application.Models;

namespace SanityArchiver.Tests
{
    [TestClass]
    public class FileSeekerTest
    {
        [TestMethod]
        public void GetFileForSearch()
        {
            string path = @"C:\Users\sfarkas\Desktop\CSharp_Udemy";
            string fileName = "Loops.cs";
            FileInfo[] files = new DirectoryInfo(path).GetFiles(fileName);
            var result = FileSeeker.Search(path, fileName);
            Assert.IsTrue(files.Length == result.Item1.Length);
        }

        [TestMethod]
        public void GetFileForRecursiveSearch()
        {
            string path = @"C:\Users\sfarkas\Desktop";
            string fileName = "Loops.cs";
            var result = FileSeeker.Search(path, fileName);
            Assert.IsNotNull(result.Item2);
        }
    }
}
