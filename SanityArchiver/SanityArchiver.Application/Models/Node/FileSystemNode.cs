using System;
using System.Collections.ObjectModel;
using System.IO;

namespace SanityArchiver.Application.Models.Node
{
    /// <summary>
    /// PizDjec
    /// </summary>
    public class FileSystemNode
    {
        private DirectoryInfo _dir;
        private bool _isExpanded;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemNode"/> class.
        /// Its a fooken constructor, m8
        /// </summary>
        /// <param name="dir">suk a diiiiiikkkkkk</param>
        public FileSystemNode(DirectoryInfo dir)
        {
            _dir = dir;
        }

        /// <summary>
        /// Gets
        /// </summary>
        public string Name
        {
            get => _dir.Name;
        }

        /// <summary>
        /// Gets
        /// </summary>
        public string Path
        {
            get => _dir.FullName;
        }

        /// <summary>
        /// Gets Kheci!
        /// </summary>
        public ObservableCollection<FileSystemNode> Nodes { get; } = new ObservableCollection<FileSystemNode>();

        /// <summary>
        /// Gets or sets a value indicating whether.
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
                        node.LoadSubDirs();
                    }
                }
            }
        }

        /// <summary>
        /// dfndskfdskfjdsnksjdfsndkf
        /// </summary>
        public void LoadSubDirs()
        {
            try
            {
                try
                {
                    foreach (var subDir in _dir.GetDirectories())
                    {
                        Nodes.Add(new FileSystemNode(subDir));
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("is have no right");
                }
            }
            catch (IOException exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// dsfjnsdjkfdsnkfndsfkdsjnfjsdkf
        /// </summary>
        /// <returns>string </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
