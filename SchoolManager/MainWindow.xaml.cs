using SchoolManager.dao;
using SchoolManager.entity;
using SchoolManager.entity.@interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace SchoolManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SchoolDao dao;
        Class school;
        ObservableCollection<ISchool> obsList;
        public MainWindow()
        {
            InitializeComponent();
            dao= SchoolDao.GetInstance();
            school = new Class
            {
                Cname = dao.GetSchoolInfo(),
                Children = dao.GetClasses(),
            };
            obsList = new ObservableCollection<ISchool>();
            school.Children.ForEach(child => obsList.Add(child));
            classList.ItemsSource = obsList;
            updateInfo();
        }

        private void visitBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn=(Button)sender;
            Class cls=(Class)btn.DataContext;
            new ClassWindow(cls).ShowDialog();
            
            updateInfo();
            cls.OnPropertyChanged(nameof(cls.Count));
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are you sure to delete this class?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                Class cls = (Class)btn.DataContext;
                if(cls.Count > 0)
                {
                    MessageBox.Show("Please remove students first");
                    return;
                }
                obsList.Remove(cls);
                school.Children.Remove(cls);
                dao.DeleteClass(cls.Cid);
                updateInfo();
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            InputWindow inputWindow = new InputWindow();
            inputWindow.ShowDialog();
            if (inputWindow.DialogResult == false)
                return;

            if (dao.UpdateSchool(inputWindow.Input) > 0)
            {
                school.Cname = inputWindow.Input;
                updateInfo();
            }
            else
            {
                MessageBox.Show("Update failed");
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            InputWindow inputWindow = new InputWindow();
            inputWindow.ShowDialog();
            if(inputWindow.DialogResult==false)
            {
                return;
            }

            int id = dao.AddClass(inputWindow.Input);
            Class cls = new Class
            {
                Cname = inputWindow.Input,
                Cid = id
            };
            obsList.Add(cls);
            school.Children.Add(cls);
            updateInfo();
        }

        public void logBtn_Click(object sender,RoutedEventArgs e)
        {
            new LogWindow(dao.GetLog()).Show();
        }

        private void updateInfo()
        {
            schoolInfoLabel.Content = $"School Name: {school.Cname}\rClass Count: {school.Children.Count}\rStudent Count: {school.Count}";

        }
    }
}
