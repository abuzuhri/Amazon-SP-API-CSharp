using FikaAmazonAPI.AmazonSpApiSDK.Models.Restrictions;
using FikaAmazonAPI.Parameter.Restrictions;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class RestrictionService : RequestService
    {
        public RestrictionService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public RestrictionList GetListingsRestrictions(ParameterGetListingsRestrictions parameter) =>
            Task.Run(() => GetListingsRestrictionsAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<RestrictionList> GetListingsRestrictionsAsync(ParameterGetListingsRestrictions parameter)
        {
            if (parameter.marketplaceIds == null || parameter.marketplaceIds.Count == 0)
            {
                parameter.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);
            }
            var param = parameter.getParameters();
            await CreateAuthorizedRequestAsync(RestrictionsApiUrls.GetListingsRestrictions, RestSharp.Method.Get, param);
            return await ExecuteRequestAsync<RestrictionList>(Utils.RateLimitType.Restrictions_GetListingsRestrictions);
        }
    }
}
