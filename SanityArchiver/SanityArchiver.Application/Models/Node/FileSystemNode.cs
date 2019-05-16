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
        private DispatcherTimer _timer;

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
                    foreach (var node in Nodes)
                    {
                        node.LoadContent();
                    }
                }
            }
        }

        /// <summary>
        /// Start a timer to refresh the node content periodically.
        /// </summary>
        public void StartTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (sender, args) => LoadContent();
            _timer.Start();
        }

        /// <summary>
        /// Stop a timer of the node.
        /// </summary>
        public void StopStimer()
        {
            _timer.Stop();
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
        /// sbfbfkjfskfjbkjfdfjkbdsjkf
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
        /// dfdfsdfsdfdfdsfdsfdsffsfsf
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
