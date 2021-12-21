using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public partial class DescriptionData
    {
        public string Title { get; set; }
        public int? MaxAggregateShipQuantity { get; set; }
        public int? MaxOrderQuantity { get; set; }


    }
}
