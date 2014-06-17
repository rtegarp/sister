using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace RMIServer
{
    public class XmlReader : MarshalByRefObject, IXmlReader
    {
        public string ReadXML(string tipe)
        {
            Dictionary<string, string> ListXML = new Dictionary<string, string>();
            ListXML.Add("Alamat Balai", "http://data.bmkg.go.id/alamatbalai.xml");
            ListXML.Add("Alamat Stasiun", "http://data.bmkg.go.id/alamatstasiun.xml");
            ListXML.Add("Pejabat BBMKG", "http://data.bmkg.go.id/pejabatBBMKG1.xml");
            ListXML.Add("Cuaca Dunia", "http://data.bmkg.go.id/cuaca_dunia_1.xml");
            ListXML.Add("Gelombang Tinggi", "http://data.bmkg.go.id/daerah_gelombang_tinggi.xml");

            string xml = "";
            ListXML.TryGetValue(tipe, out xml);

            Dictionary<string, string> ListKeyword = new Dictionary<string, string>();
            ListKeyword.Add("Alamat Balai", "Row");
            ListKeyword.Add("Alamat Stasiun", "Row");
            ListKeyword.Add("Pejabat BBMKG", "Pejabat");
            ListKeyword.Add("Cuaca Dunia", "Row");
            ListKeyword.Add("Gelombang Tinggi", "Row");

            string keyword = "";
            ListKeyword.TryGetValue(tipe, out keyword);

            XDocument doc = XDocument.Load(xml);
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
    }
}
