using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using SanityArchiver.Application.Models.ViewModel;
using SanityArchiver.Application.Models.Node;

namespace SanityArchiver.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _vm = new MainViewModel();
        private List<FileInfo> _clipBoard = new List<FileInfo>();
        private DirectoryInfo _actualDir;
        private FileSystemNode _actualNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
            btnPaste.IsEnabled = false;
        }

        /// <summary>
        /// jshbfjsdhbfsdjhfsbdhjfdsbjhs
        /// </summary>
        /// <param name="sender">dfdsfsfdsfsf</param>
        /// <param name="e">dsfdfdfdsfsfs</param>
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // ((FileSystemNode)e.OldValue)?.StopStimer();

            _actualNode = (FileSystemNode)e.NewValue;
            DataGrid1.ItemsSource = _actualNode.Files;

            // node.StartTimer();

            _actualDir = _actualNode.Dir;
            dirLabel.Content = $"Selected directory: {_actualDir.FullName}";
        }

        /// <summary>
        /// ewereklrerktnkjtrjktnerjrekjtekt
        /// </summary>
        private void GetSelectedFiles()
        {
            _clipBoard.Clear();
            foreach (var item in DataGrid1.Items)
            {
                var checkbox = DataGrid1.Columns[0].GetCellContent(item) as CheckBox;
                if ((bool)checkbox.IsChecked)
                {
                    _clipBoard.Add((FileInfo)item);
                }
            }
        }

        /// <summary>
        /// Event handler for copy button. Copies the selected file(s) to another directory.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Events</param>
        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            btnPaste.IsEnabled = true;
            GetSelectedFiles();
            _vm.SetDelegateToCopy();
        }

        /// <summary>
        /// Event handler for move button. Moves selected file(s) to another directory.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Events</param>
        private void BtnMove_Click(object sender, RoutedEventArgs e)
        {
            btnPaste.IsEnabled = true;
            GetSelectedFiles();
            _vm.SetDelegateToMove();
        }

        /// <summary>
        /// Event handler for delete button. Deletes selected file(s).
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Events</param>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedFiles();
            _vm.DeleteFiles(_clipBoard);
            _actualNode.LoadContent();
        }

        private void BtnPaste_Click(object sender, RoutedEventArgs e)
        {
            foreach (FileInfo file in _clipBoard)
            {
                _vm.HandleFileAction(file, _actualDir);
                _actualNode.LoadContent();
            }
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var rootDir = _actualDir;
            var pattern = SearchBox.Text;
            var searchResults = new ObservableCollection<FileInfo>();
            var results = _vm.SearchFile(rootDir, pattern);
            foreach (var result in results)
            {
                searchResults.Add(result);
            }

            DataGrid1.ItemsSource = searchResults;
            SearchBox.Text = "Search";
        }

        private void CompressBtn_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedFiles();
            _vm.CompressFiles(_clipBoard, _actualDir);
            _actualNode.LoadContent();
        }
    }
}