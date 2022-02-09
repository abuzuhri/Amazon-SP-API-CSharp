using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShipmentInvoicing
{
    public partial class ShipmentItem
    {
        public string ASIN { get; set; }
        public string SellerSKU { get; set; }
        public string OrderItemId { get; set; }
        public string Title { get; set; }
        public int? QuantityOrdered { get; set; }
        public Money ItemPrice { get; set; }
        public Money ShippingPrice { get; set; }
        public Money GiftWrapPrice { get; set; }
        public Money ShippingDiscount { get; set; }
        public Money PromotionDiscount { get; set; }
        public IList<string> SerialNumbers { get; set; }

    }
}
