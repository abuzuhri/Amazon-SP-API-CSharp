using FikaAmazonAPI.Utils;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.SampleCode
{
    public class CatalogItemsSample
    {
        AmazonConnection amazonConnection;
        public CatalogItemsSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        [Obsolete("This method deprecated in June 2022. Please use GetCatalogItem(ParameterGetCatalogItem parameterListCatalogItem) instead.", true)]
        public void GetCatalogItemAsync()
        {
            var item = amazonConnection.CatalogItem.GetCatalogItem("B00CZC5F0G");

        }

        public void ListCatalogCategories()
        {
            var item = amazonConnection.CatalogItem.ListCatalogCategories("B00CZC5F0G");

        }

        [Obsolete("This method deprecated in June 2022. Please use SearchCatalogItems202204 instead.", true)]
        public void ListCatalogItems()
        {
            var items = amazonConnection.CatalogItem.ListCatalogItems(new Parameter.CatalogItems.ParameterListCatalogItems()
            {
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                Query = "740985280133"
            });
        }

        public async Task GetCatalogItem()
        {
            var data = await amazonConnection.CatalogItem.GetCatalogItem202204Async(
                    new Parameter.CatalogItems.ParameterGetCatalogItem
                    {
                        ASIN = "B00JK2YANC",
                        includedData = new[] { IncludedData.attributes,
                                                       IncludedData.salesRanks,
                                                       IncludedData.summaries,
                                                       IncludedData.productTypes,
                                                       IncludedData.relationships,
                                                       IncludedData.dimensions,
                                                       IncludedData.identifiers,
                                                       IncludedData.images }
                    });
        }

        public async Task SearchCatalogItems()
        {
            var data = await amazonConnection.CatalogItem.SearchCatalogItems202204Async(
                new Parameter.CatalogItems.ParameterSearchCatalogItems202204
                {
                    keywords = new[] { "vitamin c" },
                    includedData = new[] { IncludedData.attributes,
                                                   IncludedData.salesRanks,
                                                   IncludedData.summaries,
                                                   IncludedData.productTypes,
                                                   IncludedData.relationships,
                                                   IncludedData.dimensions,
                                                   IncludedData.identifiers,
                                                   IncludedData.images }
                });
        }
    }
}
