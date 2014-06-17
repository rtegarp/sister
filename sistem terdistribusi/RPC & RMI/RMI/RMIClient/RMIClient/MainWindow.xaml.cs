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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RMIServer;

namespace RMIClient
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

            TcpChannel tcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(tcpChannel, true);
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
            Type requiredType = typeof(IXmlReader);
            IXmlReader remoteObject = (IXmlReader)Activator.GetObject(requiredType,
            "tcp://localhost:9999/XMLReader");

            txtContent.Text = remoteObject.ReadXML(cbTipe.SelectedItem.ToString());
        }
    }
}
