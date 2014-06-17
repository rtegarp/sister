using System;
using System.Collections.Generic;
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
using System.Xml.Linq;
using tugasSisterPrak3.ServiceReference1;
using tugasSisterPrak3.NewYorkStockExchange;
using tugasSisterPrak3.GlobalWeather;

namespace tugasSisterPrak3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //osVodigiWS.osVodigiServiceSoapClient ws = new osVodigiWS.osVodigiServiceSoapClient();
        CurrencyConvertorSoapClient cc = new CurrencyConvertorSoapClient("CurrencyConvertorSoap");
        StockQuoteSoapClient nyse = new StockQuoteSoapClient("StockQuoteSoap");
        GlobalWeatherSoapClient gw = new GlobalWeatherSoapClient("GlobalWeatherSoap");
        public MainWindow()
        {
            InitializeComponent();
            //ws.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri(Utility.GetWebserviceURL()));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            valueTxt.Text = cc.ConversionRate((Currency)Enum.Parse(typeof(Currency), uang1.Text), (Currency)Enum.Parse(typeof(Currency), uang2.Text)).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            XDocument doc = new XDocument();
            string xml = nyse.GetQuote(invokeinput.Text);
            File.WriteAllText("stockquote.xml", xml);
            doc = XDocument.Load("stockquote.xml");
            valueTxt2.Text = XmlParser(doc, "Stock");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private string XmlParser(XDocument doc, string keyword)
        {
            string content = "";
            foreach (XElement element in doc.Descendants(keyword))
            {
                foreach (XElement childElement in element.Descendants())
                {
                    content += String.Format("{0} : {1}", childElement.Name, childElement.Value);
                    content += Environment.NewLine;
                }
                content += Environment.NewLine;
            }
            return content;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            XDocument doc = new XDocument();
            string xml = gw.GetWeather(Kota.Text, Negara.Text);
            File.WriteAllText("currentWeather.xml", xml);
            doc = XDocument.Parse(File.ReadAllText("currentWeather.xml"));
            valueTxt3.Text = XmlParser(doc, "CurrentWeather");
        }
    }
}
