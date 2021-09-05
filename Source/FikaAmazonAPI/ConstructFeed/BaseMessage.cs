using FikaAmazonAPI.ConstructFeed.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.ConstructFeed
{
    public class BaseMessage
    {
        public int MessageID { get; set; }

        public OperationType OperationType { get; set; }

        public PriceMessage Price { get; set; }
        
        public InventoryMessage Inventory { get; set; }

        [XmlIgnore]
        public bool InventorySpecified { get { return Inventory != null; } }
        [XmlIgnore]
        public bool PriceSpecified{ get { return Price != null; }}
        public ProductMessage Product { get; set; }
        [XmlIgnore]
        public bool ProductSpecified { get { return Price != null; } }
    }
}
