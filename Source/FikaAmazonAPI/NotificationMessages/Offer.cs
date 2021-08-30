using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.NotificationMessages
{
    public partial class Offer
    {
        public string SellerId { get; set; }
        public string SubCondition { get; set; }
        public SellerFeedbackRating SellerFeedbackRating { get; set; }
        public ShippingTime ShippingTime { get; set; }
        public AmountValue ListingPrice { get; set; }
        public AmountValue Shipping { get; set; }
        public ShipsFrom ShipsFrom { get; set; }
        public bool IsFulfilledByAmazon { get; set; }
        public bool IsBuyBoxWinner { get; set; }
        public string ConditionNotes { get; set; }
        public PrimeInformation PrimeInformation { get; set; }
        public bool IsFeaturedMerchant { get; set; }
    }
}
