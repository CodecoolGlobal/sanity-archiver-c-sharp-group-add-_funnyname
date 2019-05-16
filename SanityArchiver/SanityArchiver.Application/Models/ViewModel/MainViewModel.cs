using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SanityArchiver.Application.Models.Node;
using SanityArchiver.Application.Models.FileHandling;

namespace SanityArchiver.Application.Models.ViewModel
{
    /// <summary>
    /// The main aggregator class that connects the model classes with the UI
    /// </summary>
    public class MainViewModel
    {
        private HandlerDelegate _handlerDelegate;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// It loads the nodes that are representing the root directory of the logical drives
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

        private delegate void HandlerDelegate(FileInfo file, DirectoryInfo dir);

        /// <summary>
        /// Gets or sets the files contained by the actual node (directory)
        /// </summary>
        public ObservableCollection<FileInfo> Files { get; set; } = new ObservableCollection<FileInfo>();

        /// <summary>
        /// Gets the Nodes that are representing the subDirectory
        /// </summary>
        public ObservableCollection<FileSystemNode> Nodes { get; } = new ObservableCollection<FileSystemNode>();

        /// <summary>
        /// kekfgdfgfgfdgfdgfdgfdg
        /// </summary>
        /// <param name="file">lol</param>
        /// <param name="dir">llol</param>
        public void HandleFileAction(FileInfo file, DirectoryInfo dir)
        {
            _handlerDelegate.Invoke(file, dir);
        }

        /// <summary>
        /// sets the class delegate function to Copy
        /// </summary>
        public void SetDelegateToCopy()
        {
            _handlerDelegate = FileHandler.Copy;
        }

        /// <summary>
        /// sets the class delegate to move
        /// </summary>
        public void SetDelegateToMove()
        {
            _handlerDelegate = FileHandler.Move;
        }

        /// <summary>
        /// Deletes passed files.
        /// </summary>
        /// <param name="clipBoard">List<FileInfo></param>
        public void DeleteFiles(List<FileInfo> clipBoard)
        {
            foreach (FileInfo file in clipBoard)
            {
                FileHandler.DeleteFile(file);
            }
        }
    }
}
