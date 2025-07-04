using FikaAmazonAPI.Parameter.ListingItem;

namespace FikaAmazonAPI.SampleCode
{
    internal class ProductTypeSample
    {

        AmazonConnection amazonConnection;
        public ProductTypeSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }


        private void SearchDefinitionsProductTypes()
        {
            var list = amazonConnection.ProductType.SearchDefinitionsProductTypes(
                new Parameter.ProductTypes.SearchDefinitionsProductTypesParameter()
                {
                    keywords = new List<string> { String.Empty },
                });

        }
        private void GetDefinitionsProductType()
        {
            var def = amazonConnection.ProductType.GetDefinitionsProductType(
                new Parameter.ProductTypes.GetDefinitionsProductTypeParameter()
                {
                    productType = "PRODUCT",
                    requirements = Requirements.LISTING,
                    locale = AmazonSpApiSDK.Models.ProductTypes.LocaleEnum.en_US
                });
        }


    }
}
