using FikaAmazonAPI.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Test
{
    [TestClass]
    public class ProductPricing
    {
        AmazonConnection amazonConnection;

        public ProductPricing()
        {
            amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = Environment.GetEnvironmentVariable("AccessKey"),
                SecretKey = Environment.GetEnvironmentVariable("SecretKey"),
                RoleArn = Environment.GetEnvironmentVariable("RoleArn"),
                ClientId = Environment.GetEnvironmentVariable("ClientId"),
                ClientSecret = Environment.GetEnvironmentVariable("ClientSecret"),
                RefreshToken = Environment.GetEnvironmentVariable("RefreshToken"),
                MarketPlace = MarketPlace.UnitedArabEmirates

            });
        }



        [TestMethod]
        public void GetPricing()
        { 
            var data = amazonConnection.ProductPricing.GetPricing(new Parameter.ProductPricing.ParameterGetPricing()
            {
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                Asins = new string[] { "B00CZC5F0G" }
            });
        }

        [TestMethod]
        public void GetCompetitivePricing()
        {
            var data = amazonConnection.ProductPricing.GetCompetitivePricing(new Parameter.ProductPricing.ParameterGetCompetitivePricing()
            {
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                Asins = new string[] { "B00CZC5F0G" },

            });
        }

        [TestMethod]
        public void GetListingOffers()
        {
            var data = amazonConnection.ProductPricing.GetListingOffers(new Parameter.ProductPricing.ParameterGetListingOffers()
            {
                ItemCondition = ItemCondition.New,
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                SellerSKU = "8809647390015"
            });
        }


        [TestMethod]
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

