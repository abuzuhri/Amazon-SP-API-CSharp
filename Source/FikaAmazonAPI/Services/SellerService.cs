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



        public List<MarketplaceParticipation> GetMarketplaceParticipations() =>
                Task.Run(() => GetMarketplaceParticipationsAsync()).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<MarketplaceParticipation>> GetMarketplaceParticipationsAsync()
        {
            await CreateAuthorizedRequestAsync(SellersApiUrls.GetMarketplaceParticipations, RestSharp.Method.Get);
            var response = await ExecuteRequestAsync<GetMarketplaceParticipationsResponse>(RateLimitType.Sellers_GetMarketplaceParticipations);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
