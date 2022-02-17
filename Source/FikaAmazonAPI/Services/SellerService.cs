using FikaAmazonAPI.AmazonSpApiSDK.Models.Sellers;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<List<MarketplaceParticipation>> GetMarketplaceParticipationsAsync()
        {
            await CreateAuthorizedRequestAsync(SellersApiUrls.GetMarketplaceParticipations, RestSharp.Method.GET);
            var response = await ExecuteRequestAsync<GetMarketplaceParticipationsResponse>(RateLimitType.Sellers_GetMarketplaceParticipations);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
