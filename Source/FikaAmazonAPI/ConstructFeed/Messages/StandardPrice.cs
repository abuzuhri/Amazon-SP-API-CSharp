using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public class StandardPrice
    {
        [XmlText]
        public decimal Value { get; set; }
        [XmlAttribute]
        public string currency { get; set; }
    }
}
