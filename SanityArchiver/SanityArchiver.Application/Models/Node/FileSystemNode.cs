using System;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Data;

namespace SanityArchiver.Application.Models.Node
{
    /// <summary>
    /// PizDjec
    /// </summary>
    public class FileSystemNode
    {
        private bool _isExpanded;
        private FileSystemWatcher _watcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemNode"/> class.
        /// Its a fooken constructor, m8
        /// </summary>
        /// <param name="dir">suk a diiiiiikkkkkk</param>
        public FileSystemNode(DirectoryInfo dir)
        {
            Dir = dir;
        }

        /// <summary>
        /// Gets the shit out of you
        /// </summary>
        public DirectoryInfo Dir { get; }

        /// <summary>
        /// Gets
        /// </summary>
        public string Name
        {
            get => Dir.Name;
        }

        /// <summary>
        /// Gets
        /// </summary>
        public string Path
        {
            get => Dir.FullName;
        }

        /// <summary>
        /// Gets Kheci!
        /// </summary>
        public ObservableCollection<FileSystemNode> Nodes { get; } = new ObservableCollection<FileSystemNode>();

        /// <summary>
        /// Gets Kheci2
        /// </summary>
        public ObservableCollection<FileInfo> Files { get; } = new ObservableCollection<FileInfo>();

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
                    CreateWatcher();
                    foreach (var node in Nodes)
                    {
                        node.LoadContent();
                    }
                }
            }
        }

        /// <summary>
        /// dfndskfdskfjdsnksjdfsndkf
        /// </summary>
        public void LoadContent()
        {
            LoadFiles();
            LoadSubDirs();
        }

        /// <summary>
        /// fjdbsfjdbfjbdjhfbdjfhsbdfjhdsbfsjdf
        /// </summary>
        public void RefreshContent()
        {
            LoadFiles();
            LoadSubDirs();
        }

        /// <summary>
        /// sbfbfkjfskfjbkjfdfjkbdsjkf
        /// </summary>
        public void LoadSubDirs()
        {
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
        /// dfdfsdfsdfdfdsfdsfdsffsfsf
        /// </summary>
        public void LoadFiles()
        {
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

        /// <summary>
        /// dsfjnsdjkfdsnkfndsfkdsjnfjsdkf
        /// </summary>
        /// <returns>string </returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// dsbfsdjfsdfjbfjdshbfjsdjfhbfjshbfsdjf
        /// </summary>
        private void CreateWatcher()
        {
            _watcher = new FileSystemWatcher
            {
                Path = Dir.FullName,
                NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite,
            };
            _watcher.Changed += OnContentChange;
            _watcher.Created += OnContentChange;
            _watcher.Deleted += OnContentChange;
            _watcher.Renamed += OnContentChange;
            try
            {
                _watcher.EnableRaisingEvents = true;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// sdhbfjshbfdsjhfbdsjfbdjfbdfjfbjfbjsjfsbdfjfjfh
        /// </summary>
        /// <param name="source">sfjksdnfkdjnfdkjnfkfdskfjfkjfnds</param>
        /// <param name="fileEvent">sfksnfjnfkdsfkjfndkf</param>
        private void OnContentChange(object source, FileSystemEventArgs fileEvent)
        {
            ListCollectionView view = (ListCollectionView)CollectionViewSource.GetDefaultView(Files);
        }
    }
}
