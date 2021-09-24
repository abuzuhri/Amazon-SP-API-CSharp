using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Sample
{
    public class CatalogItemsSample
    {
        AmazonConnection amazonConnection;
        public CatalogItemsSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        
        public void GetCatalogItem()
        {
            var item = amazonConnection.CatalogItem.GetCatalogItem(MarketPlace.UnitedArabEmirates.ID, "B00CZC5F0G");

        }
        
        public void ListCatalogCategories()
        {
            var item = amazonConnection.CatalogItem.ListCatalogCategories(MarketPlace.UnitedArabEmirates.ID, "B00CZC5F0G");

        }

        public void ListCatalogItems()
        {
            var items = amazonConnection.CatalogItem.ListCatalogItems(new Parameter.CatalogItems.ParameterListCatalogItems()
            {
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                Query = "740985280133"
            });
        }
    }
}
