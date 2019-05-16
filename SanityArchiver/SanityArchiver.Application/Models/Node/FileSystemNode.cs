using System;
using System.Collections.ObjectModel;
using System.IO;

namespace SanityArchiver.Application.Models.Node
{
    /// <summary>
    /// The instances of this class are representing the directories of the TreeView
    /// </summary>
    public class FileSystemNode
    {
        private bool _isExpanded;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemNode"/> class.
        /// </summary>
        /// <param name="dir">DirectoryInfo object, the directory of this node</param>
        public FileSystemNode(DirectoryInfo dir)
        {
            Dir = dir;
        }

        /// <summary>
        /// Gets the DirectoryInfo object of the node
        /// </summary>
        public DirectoryInfo Dir { get; }

        /// <summary>
        /// Gets the nem of the directory
        /// </summary>
        public string Name => Dir.Name;

        /// <summary>
        /// Gets the full path of the directory
        /// </summary>
        public string Path => Dir.FullName;

        /// <summary>
        /// Gets the the collection of the nodes that represent the subdirectories
        /// </summary>
        public ObservableCollection<FileSystemNode> Nodes { get; } = new ObservableCollection<FileSystemNode>();

        /// <summary>
        /// Gets the collection of the files within the node (this directory)
        /// </summary>
        public ObservableCollection<FileInfo> Files { get; } = new ObservableCollection<FileInfo>();

        /// <summary>
        /// Gets or sets a value indicating whether the TreeViewItem (that represents this node) is expanded or not.
        /// </summary>
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                if (_isExpanded)
                {
                    foreach (var node in Nodes)
                    {
                        node.LoadContent();
                    }
                }
            }
        }

        /// <summary>
        /// Loads the subDirectories (nodes) and the contained files
        /// </summary>
        public void LoadContent()
        {
            LoadFiles();
            LoadSubDirs();
        }

        /// <summary>
        /// Loads the subDirectories (nodes) of this node (directory)
        /// </summary>
        public void LoadSubDirs()
        {
            Nodes.Clear();
            try
            {
                foreach (var subDir in Dir.GetDirectories())
                {
                    Nodes.Add(new FileSystemNode(subDir));
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (UnauthorizedAccessException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Loads the files contained by this node (directory)
        /// </summary>
        public void LoadFiles()
        {
            Files.Clear();
            try
            {
                foreach (var file in Dir.GetFiles())
                {
                    Files.Add(file);
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (UnauthorizedAccessException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
