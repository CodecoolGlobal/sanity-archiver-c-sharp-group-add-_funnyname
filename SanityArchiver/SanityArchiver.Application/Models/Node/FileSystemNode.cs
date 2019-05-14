using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver.Application.Models.Node
{
    class FileSystemNode
    {
        private static int instanceCounter = 0;
        public int ID { get; set;}
        public string  Name { get; set; }
        public string  Path { get; set; }
        public bool Opened { get; set; }
        public Dictionary<string, FileInfo> Files = new Dictionary<string, FileInfo>();
        public Dictionary<string, DirectoryInfo> Directories = new Dictionary<string, DirectoryInfo>();
        public Dictionary<string, FileInfo> SelectedFiles = new Dictionary<string, FileInfo>();

        public FileSystemNode(DirectoryInfo Dir)
        {
            instanceCounter++;
            ID = instanceCounter;
            Name = Dir.Name;
            Path = Dir.FullName;
            Opened = true;

        }
    }
}
