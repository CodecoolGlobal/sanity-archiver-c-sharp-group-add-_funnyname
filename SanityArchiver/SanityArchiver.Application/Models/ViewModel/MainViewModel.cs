﻿using System;
using System.IO;
using System.Collections.ObjectModel;
using SanityArchiver.Application.Models.Node;

namespace SanityArchiver.Application.Models.ViewModel
{
    /// <summary>
    /// The main aggregator class that connects the model classes with the UI
    /// </summary>
    public class MainViewModel
    {
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

        /// <summary>
        /// Gets or sets the files contained by the actual node (directory)
        /// </summary>
        public ObservableCollection<FileInfo> Files { get; set; } = new ObservableCollection<FileInfo>();

        /// <summary>
        /// Gets the Nodes that are representing the subDirectory
        /// </summary>
        public ObservableCollection<FileSystemNode> Nodes { get; } = new ObservableCollection<FileSystemNode>();
    }
}
