using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Test
{
    [TestClass]
    public class Solicitations
    {
        AmazonConnection amazonConnection;
        public Solicitations()
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
        public void GetSolicitationActionsForOrder()
        {
            ParameterMarketplaceId parameterMarketplaceId = new ParameterMarketplaceId(MarketPlace.UnitedArabEmirates.ID);
            var data = amazonConnection.Solicitations.GetSolicitationActionsForOrder("405-3087470-5953115", parameterMarketplaceId.getParameters());
        }

        [TestMethod]
        public void CreateProductReviewAndSellerFeedbackSolicitation()
        {
            ParameterMarketplaceId parameterMarketplaceId = new ParameterMarketplaceId(MarketPlace.UnitedArabEmirates.ID);
            var data = amazonConnection.Solicitations.CreateProductReviewAndSellerFeedbackSolicitation("405-3087470-5953115", parameterMarketplaceId.getParameters());
        }

    }
}
