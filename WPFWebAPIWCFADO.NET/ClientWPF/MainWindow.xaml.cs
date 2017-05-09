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

namespace ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        private readonly Uri currentUri = new Uri(@"http://localhost:61401/");
        public MainWindow()
        {
            InitializeComponent();
        }

        //get by id
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var response = client.GetAsync(currentUri).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var data = (DataTable)JsonConvert.DeserializeObject(json, typeof (DataTable));
            //var data = Newtonsoft.Json.Converters.DataTableConverter

            Grid.ItemsSource = data as IEnumerable;
        }
    }
}
