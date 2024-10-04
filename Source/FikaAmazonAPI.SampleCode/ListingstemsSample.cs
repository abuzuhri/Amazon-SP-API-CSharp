using FikaAmazonAPI.Parameter.ListingItem;
using FikaAmazonAPI.Utils;

namespace FikaAmazonAPI.SampleCode
{
    public class ListingsItemsSample
    {
        private readonly AmazonConnection amazonConnection;
        public ListingsItemsSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public async Task SetListingsItemAttribute(string sellerId)
        {
            var sku = "MP-23Q3W00058-Q898-03";
            var marketPlace = MarketPlace.Germany;

            PatchOperation[] patches = new PatchOperation[1];

            patches[0] = new PatchOperation()
            {
                op = Op.replace,
                path = "/attributes/gpsr_safety_attestation",
                value = new object[] { true }
            };

            ParameterPatchListingItem parameter = new()
            {
                listingsItemPatchRequest = new ListingsItemPatchRequest() { patches = patches, productType = "BRA" },
                sellerId = sellerId,
                sku = sku,
                marketplaceIds = new string[] { marketPlace.ID }
            };

            await amazonConnection.ListingsItem.PatchListingsItemAsync(parameter);
        }
    }
}
