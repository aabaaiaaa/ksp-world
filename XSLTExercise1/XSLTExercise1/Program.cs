using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Linq;

namespace XSLTExercise1
{
    class Program
    {
        /// <summary>
        /// Because VS 2017 community edition doesn't have built in
        /// XSLT debugging or transform view features, this is a C#
        /// implementation to allow XSLTs to be tested.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Testing XSLT (transformation)");

            // Locate target XML file, XSLT to transform and an output XML file
            string relativeFileLocation = "KerbalCadetList.xml";
            string xsltFileLocation = "KerbalNames.xslt";
            string transformedXmlOutputFileLocation = relativeFileLocation.Replace(".xml", "") + "-transformed.xml";


            TransformXmlFile(relativeFileLocation, xsltFileLocation, transformedXmlOutputFileLocation);


            UseLinqToQueryTransformedXml(transformedXmlOutputFileLocation);


            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        private static void TransformXmlFile(string relativeFileLocation, string xsltFileLocation, string transformedXmlOutputFileLocation)
        {
            XPathDocument kspXPathDoc = new XPathDocument(relativeFileLocation);
            XslCompiledTransform xslTrans = new XslCompiledTransform(true);
            xslTrans.Load(xsltFileLocation);
            using (XmlTextWriter xmlTransformedWriter = new XmlTextWriter(transformedXmlOutputFileLocation, null))
            {
                xslTrans.Transform(kspXPathDoc, null, xmlTransformedWriter);
            }
        }

        private static void UseLinqToQueryTransformedXml(string transformedXmlOutputFileLocation)
        {
            XmlDocument transformedXmlFromFile = new XmlDocument();
            transformedXmlFromFile.Load(transformedXmlOutputFileLocation);

            // Select using LINQ
            XElement readTransformedXml = XElement.Parse(transformedXmlFromFile.OuterXml);
            var query = from ele in readTransformedXml.Elements("{urn:ksp}kerbal-cadet")
                        select ele;

            OutputLinqQuerySelect(query);

            query = from ele in readTransformedXml.Elements("{urn:ksp}kerbal-cadet")
                    select ele;

            OutputLinqQuerySelect(query);

            //TODO: Where clauses to filter XML data by additional attributes and parent node attributes
        }

        private static void OutputLinqQuerySelect(IEnumerable<XElement> query)
        {
            Console.WriteLine("--query output--");
            foreach (var ele in query)
                Console.WriteLine(ele);
        }
    }
}
