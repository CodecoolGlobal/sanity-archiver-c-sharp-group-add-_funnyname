using System;
using System.IO;
using System.Collections.ObjectModel;
using SanityArchiver.Application.Models.Node;

namespace SanityArchiver.Application.Models.ViewModel
{
    /// <summary>
    /// sdkjfnsdkfnsdjkfndskjfsdkjdnfsk
    /// </summary>
    public class MainViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// dffsdfsdknknjfkjskfnsdkjsdnfksdnf
        /// </summary>
        public MainViewModel()
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var root = new DirectoryInfo(drive);
                var rootNode = new FileSystemNode(root);
                rootNode.LoadContent();
                Nodes.Add(rootNode);
            }
        }

        /// <summary>
        /// Gets or sets dsdfsddfdsf
        /// </summary>
        public ObservableCollection<FileInfo> Files { get; set; } = new ObservableCollection<FileInfo>();

        /// <summary>
        /// Gets
        /// </summary>
        public ObservableCollection<FileSystemNode> Nodes { get; } = new ObservableCollection<FileSystemNode>();

        /// <summary>
        /// ksjdfdjksfdsjknfdsjkfnsjkfsdnfjk
        /// </summary>
        public void Print()
        {
            foreach (var node in Nodes)
            {
                Console.WriteLine(node);
            }
        }
    }
}
