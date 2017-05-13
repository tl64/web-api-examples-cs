using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
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
        private static bool IsValidNumber(string text)
        {
            return !string.IsNullOrEmpty(text) && text.All(char.IsDigit);
        }

        //get all students
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.ItemsSource = null;
            var response = client.GetAsync($"{currentAddress}api/Students").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var data = (List<Student>) JsonConvert.DeserializeObject(json, typeof (List<Student>));
            MyGrid.ItemsSource = data;
        }

        //get by id
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!IsValidNumber(IdTextBox.Text))
            {
                MessageBox.Show("Enter a valid id number");
                return;
            }
            MyGrid.ItemsSource = null;
            var response = client.GetAsync($"{currentAddress}api/Students/{IdTextBox.Text}").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var data = (List<Student>) JsonConvert.DeserializeObject(json, typeof (List<Student>));
            MyGrid.ItemsSource = data;
        }
        
        //add student/studnets to DB
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MyGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("Select/Add some students");
                return;
            }
            //var selectedStudents = MyGrid.SelectedItems.OfType<Student>().ToArray();
            //var content = new StringContent(JsonConvert.SerializeObject(selectedStudents), Encoding.UTF8, "application/json");
            //var response = client.PostAsync($"{currentAddress}api/Students", content).Result;
            //MessageBox.Show(response.IsSuccessStatusCode
            //    ? "Record/Records added successfully!"
            //    : response.Content.ToString());


            var selectedStudents = MyGrid.SelectedItems.OfType<Student>().ToArray();
            var response = client.PostAsync($"{currentAddress}api/Students", selectedStudents, new JsonMediaTypeFormatter()).Result;
            MessageBox.Show(response.IsSuccessStatusCode
                ? "Record/Records added successfully!"
                : response.Content.ToString());
        }

        //delete Student by id
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //this is the version where we will delete a record entering the id from textbox
            //if (!IsValidNumber(IdTextBox.Text))
            //{
            //    MessageBox.Show("Enter a valid id number");
            //    return;
            //}
            //var selectedStudent = MyGrid.SelectedItems[0] as Student;
            //var response = client.DeleteAsync($"{currentAddress}api/Students/{IdTextBox.Text}").Result;
            //MessageBox.Show(response.IsSuccessStatusCode
            //    ? "Record/Records deleted successfully!"
            //    : response.Content.ToString());

            if (MyGrid.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a student!");
                return;
            }
            var selectedStudent = MyGrid.SelectedItems[0] as Student;
            var response = client.DeleteAsync($"{currentAddress}api/Students/{selectedStudent?.StudentId}").Result;
            MessageBox.Show(response.IsSuccessStatusCode
                ? "Record/Records deleted successfully!"
                : response.Content.ToString());
        }

        //update
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (MyGrid.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a student!");
                return;
            }
            var selectedStudent = MyGrid.SelectedItems[0] as Student;
            var response =
                client.PutAsync($"{currentAddress}api/Students/{selectedStudent?.StudentId}", selectedStudent,
                    new JsonMediaTypeFormatter()).Result;
            MessageBox.Show(response.IsSuccessStatusCode
                ? "Record/Records updated successfully!"
                : response.Content.ToString());
        }
    }
}
