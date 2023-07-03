using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FikaAmazonAPI.Parameter.ListingItem
{
    public class ParameterPutListingItem : ParameterBased
    {
        public bool Check()
        {
            if (TestCase == Constants.TestCase400)
                sku = "BadSKU";
            if (string.IsNullOrWhiteSpace(this.sellerId))
            {
                throw new InvalidDataException("SellerId is a required property for ParameterPutListingItem and cannot be null");
            }
            if (string.IsNullOrWhiteSpace(this.sku))
            {
                throw new InvalidDataException("Sku is a required property for ParameterPutListingItem and cannot be null");
            }
            if (this.marketplaceIds == null || !marketplaceIds.Any())
            {
                throw new InvalidDataException("MarketplaceIds is a required property for ParameterPutListingItem and cannot be null");
            }
            if (listingsItemPutRequest == null)
            {
                throw new InvalidDataException("ListingsItemPutRequest is a required property for ParameterPutListingItem and cannot be null");
            }
            if (string.IsNullOrWhiteSpace(this.listingsItemPutRequest.productType))
            {
                throw new InvalidDataException("ProductType is a required property for ListingsItemPutRequest and cannot be null");
            }
            if (this.listingsItemPutRequest.attributes == null)
            {
                throw new InvalidDataException("Attributes is a required property for ListingsItemPutRequest and cannot be null");
            }
            return true;
        }

        [PathParameter]
        public string sellerId { get; set; }

        [PathParameter]
        public string sku { get; set; }

        public ICollection<string> marketplaceIds { get; set; }

        public string issueLocale { get; set; }

        [BodyParameter]
        public ListingsItemPutRequest listingsItemPutRequest { get; set; }

    }

    public class ListingsItemPutRequest
    {
        public string productType { get; set; }

        public Requirements requirements { get; set; }

        public Object attributes { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Requirements
    {
        LISTING,
        LISTING_PRODUCT_ONLY,
        LISTING_OFFER_ONLY
    }
}
