﻿using FikaAmazonAPI.AmazonSpApiSDK.Models.Upload;
using FikaAmazonAPI.Parameter.Upload;
using FikaAmazonAPI.Utils;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class UploadService : RequestService
    {
        public UploadService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public UploadDestination CreateUploadDestinationForResource(ParameterCreateUploadDestinationForResource parameterObj) =>
            Task.Run(() => CreateUploadDestinationForResourceAsync(parameterObj)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<UploadDestination> CreateUploadDestinationForResourceAsync(ParameterCreateUploadDestinationForResource parameterObj)
        {
            if (parameterObj.marketplaceIds == null || parameterObj.marketplaceIds.Count == 0)
                parameterObj.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);

            var parameter = parameterObj.getParameters();

            await CreateAuthorizedRequestAsync(UploadApiUrls.CreateUploadDestinationForResource(parameterObj.resource), RestSharp.Method.Post, parameter);
            var response = await ExecuteRequestAsync<CreateUploadDestinationResponse>(RateLimitType.Upload_CreateUploadDestinationForResource);
            return response.Payload;
        }
    }
}
