using FikaAmazonAPI.AmazonSpApiSDK.Models.Sellers;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;

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
            var response = ExecuteRequest<GetMarketplaceParticipationsResponse>(RateLimitType.Sellers_GetMarketplaceParticipations);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
