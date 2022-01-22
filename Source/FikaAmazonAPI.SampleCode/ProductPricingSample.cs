using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.SampleCode
{
    public class ProductPricingSample
    {
        AmazonConnection amazonConnection;
        public ProductPricingSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public void GetPricing()
        {
            var data = amazonConnection.ProductPricing.GetPricing(new Parameter.ProductPricing.ParameterGetPricing()
            {
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                Asins = new string[] { "B00CZC5F0G" }
            });
        }

        
        public void GetCompetitivePricing()
        {
            var data = amazonConnection.ProductPricing.GetCompetitivePricing(new Parameter.ProductPricing.ParameterGetCompetitivePricing()
            {
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                Asins = new string[] { "B00CZC5F0G" },

            });
        }

        
        public void GetListingOffers()
        {
            var data = amazonConnection.ProductPricing.GetListingOffers(new Parameter.ProductPricing.ParameterGetListingOffers()
            {
                ItemCondition = ItemCondition.New,
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                SellerSKU = "8809647390015"
            });
        }


        
        public void GetItemOffers()
        {
            var data = amazonConnection.ProductPricing.GetItemOffers(new Parameter.ProductPricing.ParameterGetItemOffers()
            {
                ItemCondition = ItemCondition.New,
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                Asin = "B07K13XL4Y"
            });
        }
    }
}
