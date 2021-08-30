using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.NotificationMessages
{
    public partial class Price
    {
        public string Condition { get; set; }
        public string OfferType { get; set; }
        public long QuantityTier { get; set; }
        public AmountValue ListingPrice { get; set; }
        public AmountValue Shipping { get; set; }
        public AmountValue LandedPrice { get; set; }
        public string DiscountType { get; set; }
        public string FulfillmentChannel { get; set; }
    }
}
