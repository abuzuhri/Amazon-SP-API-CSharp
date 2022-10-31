using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.SampleCode
{
    public class ProductFeeSample
    {
        AmazonConnection amazonConnection;
        public ProductFeeSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public async Task getMyFeesEstimates()
        {
            var data = await amazonConnection.ProductFee.GetMyFeesEstimateAsync(new Parameter.ProductFee.FeesEstimateByIdRequest[]
            {
                new Parameter.ProductFee.FeesEstimateByIdRequest{
                    IdType = AmazonSpApiSDK.Models.ProductFees.IdTypeEnum.SellerSKU,
                    IdValue = "xxx",
                    FeesEstimateRequest = new AmazonSpApiSDK.Models.ProductFees.FeesEstimateRequest{
                        Identifier = "xxx",
                        IsAmazonFulfilled = true,
                        MarketplaceId = MarketPlace.UnitedKingdom.ID,
                        PriceToEstimateFees = new AmazonSpApiSDK.Models.ProductFees.PriceToEstimateFees(){
                            ListingPrice = new AmazonSpApiSDK.Models.ProductFees.MoneyType(){
                                Amount = 6.59m,
                                CurrencyCode ="GBP"
                            }
                        }
                    }
                }
            });
        }
    }
}
