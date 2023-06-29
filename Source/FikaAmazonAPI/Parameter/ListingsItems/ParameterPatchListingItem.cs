using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FikaAmazonAPI.Parameter.ListingItem
{
    public class ParameterPatchListingItem : ParameterBased
    {
        public bool Check()
        {
            if (TestCase == Constants.TestCase400)
                sku = "BadSKU";
            if (string.IsNullOrWhiteSpace(this.sellerId))
            {
                throw new InvalidDataException("SellerId is a required property for ParameterPatchListingItem and cannot be null");
            }
            if (string.IsNullOrWhiteSpace(this.sku))
            {
                throw new InvalidDataException("Sku is a required property for ParameterPatchListingItem and cannot be null");
            }
            if (this.marketplaceIds == null || !this.marketplaceIds.Any())
            {
                throw new InvalidDataException("MarketplaceIds is a required property for ParameterPatchListingItem and cannot be null");
            }
            if (this.listingsItemPatchRequest == null)
            {
                throw new InvalidDataException("ListingsItemPutRequest is a required property for ParameterPatchListingItem and cannot be null");
            }
            if (string.IsNullOrWhiteSpace(this.listingsItemPatchRequest.productType)) 
            {
                throw new InvalidDataException("ListingsItemPutRequest is a required property for ParameterPatchListingItem and cannot be null");
            }
            if (this.listingsItemPatchRequest.patches==null|| !this.listingsItemPatchRequest.patches.Any())
            {
                throw new InvalidDataException("Patches is a required property for ParameterPatchListingItem and cannot be null");
            }
            return true;    
        }

        public string sellerId { get; set; }

        public string sku { get; set; }

        public ICollection<string> marketplaceIds { get; set; }

        public string issueLocale { get; set; }

        public ListingsItemPatchRequest  listingsItemPatchRequest { get; set; }

    }

    public class ListingsItemPatchRequest
    {
        public string productType { get; set; }

        public ICollection<PatchOperation> patches { get; set; }
    }

    public class PatchOperation
    {
        public Op op { get; set; }
        public string path { get; set; }

        public ICollection<object> value { get; set; }
    }

    public enum Op
    {
        add,
        replace,
        delete
    }
}
