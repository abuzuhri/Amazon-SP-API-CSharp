using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static FikaAmazonAPI.Utils.Constants;


namespace FikaAmazonAPI.Test
{
    [TestClass]
    public class CatalogItems
    {
        AmazonConnection amazonConnection;
        public CatalogItems()
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
        public void GetCatalogItem()
        {
          var item=amazonConnection.CatalogItem.GetCatalogItem(MarketPlace.UnitedArabEmirates.ID, "B00CZC5F0G");

        }
        [TestMethod]
        public void ListCatalogCategories()
        {
          var item=amazonConnection.CatalogItem.ListCatalogCategories(MarketPlace.UnitedArabEmirates.ID, "B00CZC5F0G");

        }

        [TestMethod]
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
