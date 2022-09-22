using System.Collections.Generic;
using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    [XmlRoot(ElementName = "CartonContentsRequest")]
    public class CartonContentsRequest
    {
        [XmlElement(ElementName = "ShipmentId")]
        public string ShipmentId { get; set; }
        [XmlElement(ElementName = "NumCartons")]
        public int NumCartons { get { return Carton.Count; } }
        [XmlElement(ElementName = "Carton")]
        public List<Carton> Carton { get; set; } = new List<Carton>();
    }

    [XmlRoot(ElementName = "Carton")]
    public class Carton
    {
        [XmlElement(ElementName = "CartonId")]
        public string CartonId { get; set; }
        [XmlElement(ElementName = "Item")]
        public List<CartonItem> Item { get; set; }
    }

    [XmlRoot(ElementName = "Item")]
    public class CartonItem
    {
        [XmlElement(ElementName = "SKU")]
        public string SKU { get; set; }
        [XmlElement(ElementName = "QuantityShipped")]
        public int QuantityShipped { get; set; }
        [XmlElement(ElementName = "QuantityInCase")]
        public int QuantityInCase { get; set; }
    }
}