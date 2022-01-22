using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikaAmazonAPI.SampleCode
{
    public class SolicitationsSample
    {
        AmazonConnection amazonConnection;
        public SolicitationsSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }



        public void GetSolicitationActionsForOrder()
        {
            ParameterMarketplaceId parameterMarketplaceId = new ParameterMarketplaceId(MarketPlace.UnitedArabEmirates.ID);
            var data = amazonConnection.Solicitations.GetSolicitationActionsForOrder("405-3087470-5953115", parameterMarketplaceId.getParameters());
        }


        public void CreateProductReviewAndSellerFeedbackSolicitation()
        {
            ParameterMarketplaceId parameterMarketplaceId = new ParameterMarketplaceId(MarketPlace.UnitedArabEmirates.ID);
            var data = amazonConnection.Solicitations.CreateProductReviewAndSellerFeedbackSolicitation("405-3087470-5953115", parameterMarketplaceId.getParameters());
        }
    }
}
