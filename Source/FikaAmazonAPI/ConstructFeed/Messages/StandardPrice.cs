using System.Globalization;
using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public class StandardPrice
    {
        [XmlIgnore]
        public decimal Value { get; set; }

        [XmlText]
        public string ValueString
        {
            get => Value.ToString(CultureInfo.InvariantCulture);
            set => Value = decimal.Parse(value, CultureInfo.InvariantCulture);
        }

        [XmlAttribute]
        public string currency { get; set; }
        public string start_at { get; set; }
        public string end_at { get; set; }
    }
}
