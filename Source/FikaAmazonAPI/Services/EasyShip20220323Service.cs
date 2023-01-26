using FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323;
using FikaAmazonAPI.Parameter.EasyShip;
using FikaAmazonAPI.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class EasyShip20220323Service : RequestService
    {
        public EasyShip20220323Service(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }



        public ListHandoverSlotsResponse ListHandoverSlots(ListHandoverSlotsRequest listHandoverSlotsRequest) =>
            Task.Run(() => ListHandoverSlotsAsync(listHandoverSlotsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ListHandoverSlotsResponse> ListHandoverSlotsAsync(ListHandoverSlotsRequest listHandoverSlotsRequest, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(listHandoverSlotsRequest.MarketplaceId))
                listHandoverSlotsRequest.MarketplaceId = AmazonCredential.MarketPlace.ID;

            await CreateAuthorizedRequestAsync(EasyShip20220323.ListHandoverSlots, RestSharp.Method.Post, postJsonObj: listHandoverSlotsRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListHandoverSlotsResponse>(RateLimitType.EasyShip_ListHandoverSlots, cancellationToken);
            return response;
        }

        public Package GetScheduledPackage(ParameterGetScheduledPackage Parameter) =>
            Task.Run(() => GetScheduledPackageAsync(Parameter)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<Package> GetScheduledPackageAsync(ParameterGetScheduledPackage parameterGetScheduledPackage, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(parameterGetScheduledPackage.marketplaceId))
                parameterGetScheduledPackage.marketplaceId = AmazonCredential.MarketPlace.ID;

            var parameter = parameterGetScheduledPackage.getParameters();
            await CreateAuthorizedRequestAsync(EasyShip20220323.GetScheduledPackage, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<Package>(RateLimitType.EasyShip_GetScheduledPackage, cancellationToken);
            return response;
        }


        public Package CreateScheduledPackage(CreateScheduledPackageRequest createScheduledPackageRequest) =>
            Task.Run(() => CreateScheduledPackageAsync(createScheduledPackageRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<Package> CreateScheduledPackageAsync(CreateScheduledPackageRequest createScheduledPackageRequest, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(createScheduledPackageRequest.MarketplaceId))
                createScheduledPackageRequest.MarketplaceId = AmazonCredential.MarketPlace.ID;

            await CreateAuthorizedRequestAsync(EasyShip20220323.CreateScheduledPackage, RestSharp.Method.Post, postJsonObj: createScheduledPackageRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<Package>(RateLimitType.EasyShip_CreateScheduledPackage, cancellationToken);
            return response;
        }



        public Packages UpdateScheduledPackages(UpdateScheduledPackagesRequest updateScheduledPackagesRequest) =>
            Task.Run(() => UpdateScheduledPackagesAsync(updateScheduledPackagesRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<Packages> UpdateScheduledPackagesAsync(UpdateScheduledPackagesRequest updateScheduledPackagesRequest, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(updateScheduledPackagesRequest.MarketplaceId))
                updateScheduledPackagesRequest.MarketplaceId = AmazonCredential.MarketPlace.ID;

            await CreateAuthorizedRequestAsync(EasyShip20220323.UpdateScheduledPackages, RestSharp.Method.Patch, postJsonObj: updateScheduledPackagesRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<Packages>(RateLimitType.EasyShip_UpdateScheduledPackages, cancellationToken);
            return response;
        }
    }
}
