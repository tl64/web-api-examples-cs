using System;
using System.Collections.Generic;
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

namespace ClientSide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<string> filesList = new List<string>();
        private static string rootPath = @"C:\Users\HP\Desktop\Test\Server files";
        private static string pageAddress = @"http://localhost:61852/";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listOfFiles.Visibility = Visibility.Visible;
            var responseString = string.Empty;
            //listOfFiles.ItemsSource = Directory.GetFiles(rootPath);
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(pageAddress + "api/Files").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    responseString = responseContent.ReadAsStringAsync().Result;
                } 
            }
            ContentLabel.Content = responseString;
        }
    }
}
