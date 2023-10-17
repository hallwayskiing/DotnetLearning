using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace FileBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<FileNode>obsList= new ObservableCollection<FileNode>();

        public MainWindow()
        {
            InitializeComponent();
            FileNode node = new()
            {
                FileName = "C:",
                Path = "C:",
                Type = "disk"
            };
            fileTree.Items.Add(node);
            fileList.ItemsSource = obsList;
        }

        private void FileTreeItem_Selected(object sender, RoutedEventArgs e)
        {
            try
            {               
                var item = (TreeViewItem)sender;
                var node = (FileNode)item.DataContext;
                obsList.Clear();
                var list = new DirectoryInfo(node.Path).GetFileSystemInfos();
                foreach (var file in list)
                {
                    var child = new FileNode
                    {
                        FileName = file.Name,
                        Path = file.FullName,
                        Type = file.Extension switch
                        {
                            ".exe" => "exe",
                            ".txt" => "txt",
                            "" => "folder",
                            _ => "other",
                        },
                        LastAccess = file.LastAccessTime.ToShortDateString()+","+ file.LastAccessTime.ToLongTimeString(),                    
                        Size=File.Exists(file.FullName)?new FileInfo(file.FullName).Length:0,
                    };
                    node.Children.Add(child);
                    obsList.Add(child);
                }
                item.IsExpanded = true;
                e.Handled = true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access Denied!");
            }
            catch { }
        }

        private void FileTreeItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = (TreeViewItem)sender;
                var node = (FileNode)item.DataContext;

                switch (node.Type)
                {
                    case "txt":
                        Process.Start("notepad.exe", node.Path);
                        break;
                    case "exe":
                        Process.Start(node.Path);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
