using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;
using ServiceWCF;

namespace ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        private readonly string currentAddress = @"http://localhost:61401/";
        public MainWindow()
        {
            InitializeComponent();
        }

        //get all students
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var response = client.GetAsync($"{currentAddress}api/Students").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var data = (List<Student>) JsonConvert.DeserializeObject(json, typeof (List<Student>));
            Grid.ItemsSource = data;
        }

        //get by id
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!IsValidNumber(IdTextBox.Text))
            {
                MessageBox.Show("Enter a valid id number");
                return;
            }
            var response = client.GetAsync($"{currentAddress}api/Students/{IdTextBox.Text}").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var data = (List<Student>) JsonConvert.DeserializeObject(json, typeof (List<Student>));
            Grid.ItemsSource = data;
        }

        private static bool IsValidNumber(string text)
        {
            return !string.IsNullOrEmpty(text) && text.All(char.IsDigit);
        }
    }
}
