using System;
using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed
{
    [Serializable]
    public class FeedHeader
    {
        [XmlElement]
        public string DocumentVersion { get; set; }

        [XmlElement]
        public string MerchantIdentifier { get; set; }
    }
}
