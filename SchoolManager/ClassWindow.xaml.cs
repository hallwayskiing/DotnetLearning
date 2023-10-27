using SchoolManager.dao;
using SchoolManager.entity;
using SchoolManager.entity.@interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace SchoolManager
{
    /// <summary>
    /// ClassWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ClassWindow : Window
    {
        SchoolDao dao;
        ObservableCollection<ISchool> obsList;
        Class cls;
        public ClassWindow(Class _cls)
        {
            InitializeComponent();
            dao = SchoolDao.GetInstance();
            cls = _cls;
            obsList = new ObservableCollection<ISchool>();
            cls.Children.ForEach(child => obsList.Add(child));
            studentList.ItemsSource = obsList;
            updateInfo();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this student?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                Student stu = (Student)btn.DataContext;

                obsList.Remove(stu);
                cls.Children.Remove(stu);
                dao.DeleteStudent(stu.Sid);
                updateInfo();
            }
        }

        private void editClassBtn_Click(object sender, RoutedEventArgs e)
        {
            InputWindow inputWindow = new InputWindow();
            inputWindow.ShowDialog();
            if (inputWindow.DialogResult == false)
                return;

            if (dao.UpdateClass(cls.Cid, inputWindow.Input) > 0)
            {
                cls.Cname = inputWindow.Input;
                updateInfo();
            }
            else
            {
                MessageBox.Show("Update failed");
            }
        }

        private void editStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Student student = (Student)button.DataContext;

            InputWindow inputWindow = new InputWindow();
            inputWindow.ShowDialog();
            if (inputWindow.DialogResult == false)
                return;

            if (dao.UpdateStudent(student.Sid, inputWindow.Input) > 0)
            {
                student.Sname = inputWindow.Input;
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
            if (inputWindow.DialogResult == false)
                return;

            int id = dao.AddStudent(inputWindow.Input, cls.Cid);
            Student stu = new Student
            {
                Sname = inputWindow.Input,
                Sid = id,
            };
            obsList.Add(stu);
            cls.Children.Add(stu);
            updateInfo();
        }

        private void updateInfo()
        {
            classInfoLabel.Content = $"Class ID: {cls.Cid}\rClass Name: {cls.Cname}\rStudent Count: {cls.Count}";
        }
    }
}
