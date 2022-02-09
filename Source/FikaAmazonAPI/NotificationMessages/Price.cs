namespace FikaAmazonAPI.NotificationMessages
{
    public partial class Price
    {
        public string Condition { get; set; }
        public string OfferType { get; set; }
        public long QuantityTier { get; set; }
        public MoneyType ListingPrice { get; set; }
        public MoneyType Shipping { get; set; }
        public MoneyType LandedPrice { get; set; }
        public string DiscountType { get; set; }
        public string FulfillmentChannel { get; set; }
    }
}
