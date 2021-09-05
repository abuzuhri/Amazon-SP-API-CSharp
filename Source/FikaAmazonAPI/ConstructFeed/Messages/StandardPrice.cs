using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public class StandardPrice
    {
        [XmlText]
        public string Value { get; set; }
        [XmlAttribute]
        public string currency { get; set; }
    }
}
