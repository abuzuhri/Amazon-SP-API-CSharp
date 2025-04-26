using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public class StandardPrice
    {
        [XmlText]
        public decimal Value { get; set; }
        [XmlAttribute]
        public string currency { get; set; }
        public string start_at { get; set; }
        public string end_at { get; set; }
    }
}
