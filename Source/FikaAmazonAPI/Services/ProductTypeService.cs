namespace FikaAmazonAPI.Services
{
    public class ProductTypeService : RequestService
    {
        public ProductTypeService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        //public IList<Price> SearchDefinitionsProductTypes(ParameterGetPricing parameterGetPricing) =>
        //    Task.Run(() => SearchDefinitionsProductTypesAsync(parameterGetPricing)).ConfigureAwait(false).GetAwaiter().GetResult();
        //public async Task<IList<Price>> SearchDefinitionsProductTypesAsync(ParameterGetPricing parameterGetPricing)
        //{
        //    var param = parameterGetPricing.getParameters();

        //    await CreateAuthorizedRequestAsync(ProductPricingApiUrls.GetPricing, RestSharp.Method.GET, param);
        //    var response = await ExecuteRequestAsync<GetPricingResponse>(RateLimitType.ProductPricing_GetPricing);
        //    if (response != null && response.Payload != null)
        //        return response.Payload;
        //    return null;
        //}
    }
}
