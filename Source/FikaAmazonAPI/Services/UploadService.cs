using FikaAmazonAPI.AmazonSpApiSDK.Models.Upload;
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

        public UploadDestination CreateUploadDestinationForResource(ParametercreateUploadDestinationForResource parameterObj) =>
            CreateUploadDestinationForResourceAsync(parameterObj).GetAwaiter().GetResult();
        public async Task<UploadDestination> CreateUploadDestinationForResourceAsync(ParametercreateUploadDestinationForResource parameterObj)
        {

            await CreateAuthorizedRequestAsync(UploadApiUrls.CreateUploadDestinationForResource(parameterObj.resource), RestSharp.Method.POST, postJsonObj: parameterObj);
            var response = await ExecuteRequestAsync<CreateUploadDestinationResponse>(RateLimitType.Upload_CreateUploadDestinationForResource);
            return response.Payload;
        }
    }
}
