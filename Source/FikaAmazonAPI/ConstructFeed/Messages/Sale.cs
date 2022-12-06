using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public class Sale
    {
        [XmlElement(ElementName = "StartDate")]
        public string StartDate { get; set; }
        [XmlElement(ElementName = "EndDate")]
        public string EndDate { get; set; }
        [XmlElement(ElementName = "SalePrice")]
        public StandardPrice SalePrice { get; set; }
    }
}
