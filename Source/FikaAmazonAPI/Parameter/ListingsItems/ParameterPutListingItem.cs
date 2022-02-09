using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
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
            if (string.IsNullOrWhiteSpace(this.listingsItemPutRequest.ProductType)) 
            {
                throw new InvalidDataException("ProductType is a required property for ListingsItemPutRequest and cannot be null");
            }
            if (this.listingsItemPutRequest.Attributes==null)
            {
                throw new InvalidDataException("Attributes is a required property for ListingsItemPutRequest and cannot be null");
            }
            return true;
        }
        public string sellerId { get; set; }

        public string sku { get; set; }

        public IList<string> marketplaceIds { get; set; }

        public string issueLocale { get; set; }

        public ListingsItemPutRequest listingsItemPutRequest { get; set; }

    }

    public class ListingsItemPutRequest
    {
        public string ProductType { get; set; }

        public Requirements Requirements { get; set; }

        public Object Attributes { get; set; }
    }

    public enum Requirements
    {
        LISTING,
        LISTING_PRODUCT_ONLY,
        LISTING_OFFER_ONLY
    }
}
