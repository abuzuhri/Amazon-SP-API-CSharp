﻿/* 
 * Selling Partner API for Listings Items
 *
 * The Selling Partner API for Listings Items (Listings Items API) provides programmatic access to selling partner listings on Amazon. Use this API in collaboration with the Selling Partner API for Product Type Definitions, which you use to retrieve the information about Amazon product types needed to use the Listings Items API.  For more information, see the [Listings Items API Use Case Guide](doc:listings-items-api-v2021-08-01-use-case-guide).
 *
 * OpenAPI spec version: 2021-08-01
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ListingsItems
{
    /// <summary>
    /// An attribute by which to sort the returned listing items.
    /// </summary>
    /// <value>An attribute by which to sort the returned listing items.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortBy
    {
        /// <summary>
        /// Enum sku for value: sku
        /// </summary>
        [EnumMember(Value = "sku")]
        sku = 1,

        /// <summary>
        /// Enum createdDate for value: createdDate
        /// </summary>
        [EnumMember(Value = "createdDate")]
        createdDate = 2,

        /// <summary>
        /// Enum lastUpdatedDate for value: lastUpdatedDate
        /// </summary>
        [EnumMember(Value = "lastUpdatedDate")]
        lastUpdatedDate = 3
    }
}
