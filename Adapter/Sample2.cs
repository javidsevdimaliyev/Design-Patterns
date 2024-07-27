using Newtonsoft.Json;
using System;
using System.Xml;

namespace Adapter
{
    /*
      * Imagine you have a stock monitoring application that downloads stock data in XML format 
      * from multiple sources and then displays well-formatted charts and diagrams to the user.
      * At some point, you decide to enhance the application by integrating a smart third-party 
      * analysis library. However, there’s a problem: the analysis library only works with JSON data.
      */
    internal class Sample2
    {
        void Test()
        {
            // Create an XML-to-JSON adapter
            XmlToJsonAdapter adapter = new();

            // Perform analysis using the adapter
            adapter.PerformAnalysis();
        }

        //Adaptee class
        class XmlDataSource
        {
            public string GetData()
            {
                // Simulate fetching XML data
                string xmlData = "<stock><symbol>XYZ</symbol><price>100</price></stock>";
                return xmlData;
            }
        }

        // Third-Party Analysis Library (Existing Implementation)
        class ThirdPartyAnalysisLibrary
        {
            public void AnalyzeData(string jsonData)
            {
                // Perform analysis provided by the third-party library
                Console.WriteLine("Performing analysis on JSON data: " + jsonData);
            }
        }

        // The interface expected by the client
        interface IXmlToJson
        {
            void PerformAnalysis();
        }

        // XML-to-JSON Adapter class
        class XmlToJsonAdapter : IXmlToJson
        {
            public void PerformAnalysis()
            {
                // Create an XML data source
                XmlDataSource xmlDataSource = new();

                // Create a third-party analysis library
                ThirdPartyAnalysisLibrary thirdPartLib = new();

                // Get XML data
                string xmlData = xmlDataSource.GetData();

                // Convert XML data to JSON format
                string jsonData = ConvertXmlToJson(xmlData);

                // Perform analysis using the third-party library
                thirdPartLib.AnalyzeData(jsonData);
            }

            private string ConvertXmlToJson(string xmlData)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlData);

                // Convert XML to JSON
                string jsonData = JsonConvert.SerializeXmlNode(xmlDoc);
                return jsonData;
            }
        }
    }
}
