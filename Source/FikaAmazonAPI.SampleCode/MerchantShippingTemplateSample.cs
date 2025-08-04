
using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Parameter.ListingItem;
using FikaAmazonAPI.Parameter.ProductTypes;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FikaAmazonAPI.SampleCode
{
    public class MerchantShippingTemplateSample
    {
        private readonly AmazonConnection _amazonConnection;

        public MerchantShippingTemplateSample(AmazonConnection amazonConnection)
        {
            _amazonConnection = amazonConnection;
        }

        public async Task PopulateMerchantShippingGroupNamesKeys()
        {
            var parameter = new GetDefinitionsProductTypeParameter()
            {
                sellerId = _amazonConnection.GetCurrentSellerID,
                marketplaceIds = new List<string>() { MarketPlace.US.ID },
                productTypeVersion = "LATEST",
                requirements = Requirements.LISTING,
                locale = AmazonSpApiSDK.Models.ProductTypes.LocaleEnum.en_US,
                version = "LATEST",
                productType = "PRODUCT",
            };

            await _amazonConnection.MerchantShippingTemplate.PopulateMerchantShippingGroupNamesKeysAsync(parameter);

            Console.WriteLine($"MerchantShippingGroupNamesKeys populated successfully with {MerchantShippingGroupMessage.MerchantShippingGroupNamesKeys.Count} shipping templates.");

            if (MerchantShippingGroupMessage.MerchantShippingGroupNamesKeys.Count > 0)
            {
                foreach (var template in MerchantShippingGroupMessage.MerchantShippingGroupNamesKeys)
                {
                    Console.WriteLine($"MerchantShippingTemplate: '{template.Key}': '{template.Value}'");
                }
            }
        }
    }
} 