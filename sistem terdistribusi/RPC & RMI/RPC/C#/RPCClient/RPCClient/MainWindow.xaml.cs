using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RPCClient.ServiceReference1;

namespace RPCClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadComboBox();
            cbTipe.SelectedItem = "Alamat Balai";
        }

        private void LoadComboBox()
        {
            List<string> tipe = new List<string>();
            tipe.Add("Alamat Balai");
            tipe.Add("Alamat Stasiun");
            tipe.Add("Pejabat BBMKG");
            tipe.Add("Cuaca Dunia");
            tipe.Add("Gelombang Tinggi");
            cbTipe.ItemsSource = tipe;
        }

        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            Service1Client client = new Service1Client();
            txtContent.Text = client.ReadXML(cbTipe.SelectedItem.ToString());
        }
    }
}