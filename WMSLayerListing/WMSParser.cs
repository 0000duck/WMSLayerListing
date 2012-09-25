using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;

namespace WMSLayerListing
{
    class WMSParser
    {

        //constructor
       public WMSParser()
        {
            Console.WriteLine("Initialized");
        }
        
        public String xmlCache = null;
        public bool initialLoad = false;

        public List<String> getLayers(String url)
        {
            //cache GetCapabilites document
            if (xmlCache == null)
            {
                using (WebClient client = new WebClient())
                {
                    initialLoad = true;
                    xmlCache = client.DownloadString(url);
                }
            }
            
            //parse using DOM (consider using SAX - XMLReader class or XML/LINQ XDocument class for better performance) 
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlCache);
            var layers = doc.GetElementsByTagName("Layer");

            var resList = new List<String>();
            foreach (XmlElement layer in layers)
            {
                if (layer.HasAttributes)
                {
                    //get layer title
                    resList.Add(layer.GetElementsByTagName("Title")[0].InnerText);
                    //get layer name
                    //resList.Add(layer.GetElementsByTagName("Name")[0].InnerText);
                }
            }

            if (initialLoad)
            {
                initialLoad = false;
                Console.WriteLine(layers.Count.ToString() + " Layers Parsed.");
                //System.Windows.MessageBox.Show(layers.Count.ToString() + " Layers Parsed.");
            }
            return resList;
        }
    }
}
