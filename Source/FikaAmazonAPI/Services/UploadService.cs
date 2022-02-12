using FikaAmazonAPI.AmazonSpApiSDK.Models.Upload;
using FikaAmazonAPI.Parameter.Upload;
using FikaAmazonAPI.Utils;

namespace FikaAmazonAPI.Services
{
    public class UploadService : RequestService
    {
        public UploadService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public UploadDestination CreateUploadDestinationForResource(ParametercreateUploadDestinationForResource parameterObj)
        {
            
            CreateAuthorizedRequest(UploadApiUrls.CreateUploadDestinationForResource(parameterObj.resource), RestSharp.Method.POST,postJsonObj: parameterObj);
            var response = ExecuteRequest<CreateUploadDestinationResponse>(RateLimitType.Upload_CreateUploadDestinationForResource);
            return response.Payload;
        }
    }
}
