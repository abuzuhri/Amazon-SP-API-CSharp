using AmazonSpApiSDK.Models.Sellers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class SellerService : RequestService
    {
        public SellerService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }



        public List<MarketplaceParticipation> GetMarketplaceParticipations()
        {
            CreateAuthorizedRequest(SellersApiUrls.GetMarketplaceParticipations, RestSharp.Method.GET);
            var response = ExecuteRequest<GetMarketplaceParticipationsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
