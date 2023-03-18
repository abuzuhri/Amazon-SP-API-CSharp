using FikaAmazonAPI.Parameter.ListingItem;
using Microsoft.Extensions.Configuration;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.SampleCode
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>()
            .Build();


            AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = config.GetSection("FikaAmazonAPI:AccessKey").Value,
                SecretKey = config.GetSection("FikaAmazonAPI:SecretKey").Value,
                RoleArn = config.GetSection("FikaAmazonAPI:RoleArn").Value,
                ClientId = config.GetSection("FikaAmazonAPI:ClientId").Value,
                ClientSecret = config.GetSection("FikaAmazonAPI:ClientSecret").Value,
                RefreshToken = config.GetSection("FikaAmazonAPI:RefreshToken").Value,
                MarketPlaceID = config.GetSection("FikaAmazonAPI:MarketPlaceID").Value,
                SellerID = config.GetSection("FikaAmazonAPI:SellerId").Value,
                IsDebugMode = true
            });

            var search = amazonConnection.ProductType.SearchDefinitionsProductTypes(new Parameter.ProductTypes.SearchDefinitionsProductTypesParameter
            {
                keywords = new[] { "pet" }
            });

            var def = amazonConnection.ProductType.GetDefinitionsProductType(
               new Parameter.ProductTypes.GetDefinitionsProductTypeParameter()
               {
                   productType = search.ProductTypes?.FirstOrDefault()?.Name ?? "",
                   locale = AmazonSpApiSDK.Models.ProductTypes.LocaleEnum.en_US,

               });


            var x = amazonConnection.CatalogItem.GetCatalogItem202204(new FikaAmazonAPI.Parameter.CatalogItems.ParameterGetCatalogItem()
            {
                ASIN = "B01I3JW7PK",
                includedData = new List<IncludedData> {
               IncludedData.summaries,
               IncludedData.identifiers,
               IncludedData.summaries,
               IncludedData.productTypes,
               IncludedData.dimensions,
               IncludedData.images,
               IncludedData.relationships,
               IncludedData.attributes//,
               
               }
            });
            x.Attributes.Remove("street_date");
            x.Attributes.Add("storage_instructions", new[] { new {
                    value="not applicable"//, unit="Hertz"

                }});
            x.Attributes.Add("number_of_boxes", new[] { new {
                    value=1//, unit="Hertz"

                }});

            x.Attributes.Add("country_of_origin", new[] { new {
                    value= "UK"//, unit="Hertz"

                }});

            x.Attributes.Add("use_by_recommendation", new[] { new {
                    value= "not applicable"//, unit="Hertz"

                }});

            x.Attributes.Add("product_description", new[] { new {
                    value= ""//, unit="Hertz"

                }});
            x.Attributes.Add("purchasable_offer", new object[] {
                                        new{
                                                currency= amazonConnection.GetCurrentMarketplace.CurrencyCode,
                                                our_price=new []
                                                          { new{
                                                                    schedule =new[]
                                                              { new {
                                                                        value_with_tax= 59.99M
                                                                    }
                                                              }}
                                                          }
                                             }
                                      });

            x.Attributes.Add("fulfillment_availability",
                new object[] { new { fulfillment_channel_code = "DEFAULT",
                    quantity = 10 } });
            //x.Attributes["vat_level"] = new[] { new {
            //        value ="registration_not_required"//, unit="Hertz"

            //   }};
            x.Attributes.Add("condition_type", new[] { new {
                    value= "new_new"//, unit="Hertz"

                }});
            x.Attributes.Remove("variation_theme");
            x.Attributes.Remove("generic_keyword"); x.Attributes.Remove("vat_level");



            // var r = new object[] { new{ value = DateTime.Now } };
            // x.Attributes.Add("street_date", System.Text.Json.JsonSerializer.Serialize( new[] { new { value = DateTime.Now } }));//= System.Text.Json.JsonSerializer.Serialize(r);
            var putrequest = new ListingsItemPutRequest()
            {
                attributes = x.Attributes,
                productType = def.ProductType,
                requirements = Requirements.LISTING
            };

            var y = amazonConnection.ListingsItem.PutListingsItem(
                new ParameterPutListingItem()
                {
                    listingsItemPutRequest = putrequest,
                    sku = "71683-001",
                    sellerId = amazonConnection.GetCurrentSellerID
                });



            Console.ReadLine();

        }






    }
}
