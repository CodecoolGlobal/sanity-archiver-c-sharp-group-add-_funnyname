using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
        }

        /// <summary>
        /// jshbfjsdhbfsdjhfsbdhjfdsbjhs
        /// </summary>
        /// <param name="sender">dfdsfsfdsfsf</param>
        /// <param name="e">dsfdfdfdsfsfs</param>
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var node = (FileSystemNode)e.NewValue;
            DataGrid1.ItemsSource = node.Files;
        }

        /// <summary>
        /// dfjsdnfksfskjfskjfnfkjsdfkjnsfkjsd
        /// </summary>
        /// <param name="sender">sdjfkjskfnsdkfsnfs</param>
        /// <param name="e">fksjdfnjsdsdjkfndjksdjfk</param>
        private void Button_Click(object sender, RoutedEventArgs e)
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
    }
}
