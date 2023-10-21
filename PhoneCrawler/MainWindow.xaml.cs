using System;
using System.Collections.Generic;
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
using PhoneCrawler.crawler;
using PhoneCrawler.entity;

namespace PhoneCrawler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            string keyword = inputBox.Text;
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a keyword");
                return;
            }

            tipLabel.Visibility = Visibility.Visible;
            searchBtn.IsEnabled = false;

            List<PhoneInfo> results = await Crawler.GetResults(keyword);
            ResultWindow resultWindow = new ResultWindow();
            resultWindow.resList.ItemsSource = results;
            resultWindow.Show();

            tipLabel.Visibility = Visibility.Hidden;
            searchBtn.IsEnabled = true;
        }
    }
}
