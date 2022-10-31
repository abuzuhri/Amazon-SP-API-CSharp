using FikaAmazonAPI.Parameter.Upload;
using FikaAmazonAPI.Utils;

namespace FikaAmazonAPI.SampleCode
{
    public class UploadSample
    {
        AmazonConnection amazonConnection;
        public UploadSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public async Task CreateUploadDestinationForResourceAsync()
        {
            var imageHash = EasyMD5.GetMD5HashFromFile(@"C:\DataSave\tmp\amazon.png");
            var fileExtension = "png";
            var uploadRequest = new ParameterCreateUploadDestinationForResource
            {
                contentMD5 = imageHash,
                resource = "aplus/2020-11-01/contentDocuments",
                contentType = "image/" + fileExtension
            };

            var uploadResponse = await amazonConnection.Upload.CreateUploadDestinationForResourceAsync(uploadRequest);
        }
    }
}
