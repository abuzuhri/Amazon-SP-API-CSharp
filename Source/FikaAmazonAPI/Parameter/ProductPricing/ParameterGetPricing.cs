using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.ProductPricing
{
    public class ParameterGetPricing : ParameterBased
    {
        public string MarketplaceId { get; set; }
        public ICollection<string> Asins { get; set; }
        public ICollection<string> Skus { get; set; }
        public ItemType ItemType
        {
            get
            {
                if (Asins != null && Asins.Count > 0 && Skus != null && Skus.Count > 0)
                    throw new ArgumentException("Only allowed to fill Asins or Skus you cant have both");
                if (Asins != null && Asins.Count > 0)
                    return ItemType.Asin;
                if (Skus != null && Skus.Count > 0)
                    return ItemType.Sku;

                throw new ArgumentException("You cant request without fill Skus or Asins , you need to fill only of them only");
            }
        }
        public ItemCondition? ItemCondition { get; set; }
        public OfferTypeEnum? OfferType { get; set; } = OfferTypeEnum.B2C;
    }
}
