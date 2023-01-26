using FikaAmazonAPI.AmazonSpApiSDK.Models.ProductTypes;
using FikaAmazonAPI.Parameter.ProductTypes;
using FikaAmazonAPI.Utils;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class ProductTypeService : RequestService
    {
        public ProductTypeService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public ProductTypeList SearchDefinitionsProductTypes(SearchDefinitionsProductTypesParameter parameter) =>
            Task.Run(() => SearchDefinitionsProductTypesAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ProductTypeList> SearchDefinitionsProductTypesAsync(SearchDefinitionsProductTypesParameter parameter)
        {
            if (parameter.marketplaceIds == null || parameter.marketplaceIds.Count == 0)
                parameter.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);

            var param = parameter.getParameters();

            await CreateAuthorizedRequestAsync(ProductTypeApiUrls.SearchDefinitionsProductTypes, RestSharp.Method.Get, param);
            return await ExecuteRequestAsync<ProductTypeList>(RateLimitType.ProductTypes_SearchDefinitionsProductTypes);
        }


        public ProductTypeDefinition GetDefinitionsProductType(GetDefinitionsProductTypeParameter parameter) =>
            Task.Run(() => SearchDefinitionsProductTypesAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ProductTypeDefinition> SearchDefinitionsProductTypesAsync(GetDefinitionsProductTypeParameter parameter)
        {
            if (parameter.marketplaceIds == null || parameter.marketplaceIds.Count == 0)
                parameter.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);


            var param = parameter.getParameters();

            await CreateAuthorizedRequestAsync(ProductTypeApiUrls.GetDefinitionsProductType(parameter.productType), RestSharp.Method.Get, param);
            return await ExecuteRequestAsync<ProductTypeDefinition>(RateLimitType.ProductTypes_GetDefinitionsProductType);
        }
    }
}
