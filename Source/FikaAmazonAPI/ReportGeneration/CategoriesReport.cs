using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace FikaAmazonAPI.ReportGeneration
{
    public class CategoriesReport
    {
        public CategoriesData Data { get; set; } = new CategoriesData();

        public CategoriesReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;

            var xml = File.ReadAllText(path);
            var serializer = new XmlSerializer(typeof(CategoriesData));

            try
            {
                using (StringReader reader = new StringReader(xml))
                {
                    Data = (CategoriesData)serializer.Deserialize(reader);
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }

    [XmlRoot(ElementName = "attribute")]
    public class CategoryAttribute
    {

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "browseNodeAttributes")]
    public class CategoryBrowseNodeAttributes
    {

        [XmlElement(ElementName = "attribute")]
        public CategoryAttribute Attribute { get; set; }

        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "childNodes")]
    public class ChildNodes
    {

        [XmlElement(ElementName = "id")]
        public List<string> Id { get; set; }

        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "refinementsInformation")]
    public class RefinementsInformation
    {

        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
    }

    [XmlRoot(ElementName = "Node")]
    public class CategoriesRow
    {

        [XmlElement(ElementName = "browseNodeId")]
        public string BrowseNodeId { get; set; }

        [XmlElement(ElementName = "browseNodeAttributes")]
        public CategoryBrowseNodeAttributes BrowseNodeAttributes { get; set; }

        [XmlElement(ElementName = "browseNodeName")]
        public string BrowseNodeName { get; set; }

        [XmlElement(ElementName = "browseNodeStoreContextName")]
        public string BrowseNodeStoreContextName { get; set; }

        [XmlElement(ElementName = "browsePathById")]
        public string BrowsePathById { get; set; }

        [XmlElement(ElementName = "browsePathByName")]
        public string BrowsePathByName { get; set; }

        [XmlElement(ElementName = "hasChildren")]
        public bool HasChildren { get; set; }

        [XmlElement(ElementName = "childNodes")]
        public ChildNodes ChildNodes { get; set; }

        [XmlElement(ElementName = "productTypeDefinitions")]
        public string ProductTypeDefinitions { get; set; }

        [XmlElement(ElementName = "refinementsInformation")]
        public RefinementsInformation RefinementsInformation { get; set; }
    }

    [XmlRoot(ElementName = "Result")]
    public class CategoriesData
    {

        [XmlElement(ElementName = "Node")]
        public List<CategoriesRow> Node { get; set; }
    }
}