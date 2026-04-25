using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// The specific unit of measurement used to quantify this item.
    /// </summary>
    /// <value>The specific unit of measurement used to quantify this item.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UnitEnum
    {
        /// <summary>
        /// The item is measured in ounces.
        /// </summary>
        [EnumMember(Value = "OUNCES")]
        OUNCES = 1,

        /// <summary>
        /// The item is measured in pounds.
        /// </summary>
        [EnumMember(Value = "POUNDS")]
        POUNDS = 2,

        /// <summary>
        /// The item is measured in kilograms.
        /// </summary>
        [EnumMember(Value = "KILOGRAMS")]
        KILOGRAMS = 3,

        /// <summary>
        /// The item is measured in grams.
        /// </summary>
        [EnumMember(Value = "GRAMS")]
        GRAMS = 4,

        /// <summary>
        /// The item is measured in milligrams.
        /// </summary>
        [EnumMember(Value = "MILLIGRAMS")]
        MILLIGRAMS = 5,

        /// <summary>
        /// The item is measured in inches.
        /// </summary>
        [EnumMember(Value = "INCHES")]
        INCHES = 6,

        /// <summary>
        /// The item is measured in feet.
        /// </summary>
        [EnumMember(Value = "FEET")]
        FEET = 7,

        /// <summary>
        /// The item is measured in meters.
        /// </summary>
        [EnumMember(Value = "METERS")]
        METERS = 8,

        /// <summary>
        /// The item is measured in centimeters.
        /// </summary>
        [EnumMember(Value = "CENTIMETERS")]
        CENTIMETERS = 9,

        /// <summary>
        /// The item is measured in millimeters.
        /// </summary>
        [EnumMember(Value = "MILLIMETERS")]
        MILLIMETERS = 10,

        /// <summary>
        /// The item is measured in square meters.
        /// </summary>
        [EnumMember(Value = "SQUARE_METERS")]
        SQUARE_METERS = 11,

        /// <summary>
        /// The item is measured in square centimeters.
        /// </summary>
        [EnumMember(Value = "SQUARE_CENTIMETERS")]
        SQUARE_CENTIMETERS = 12,

        /// <summary>
        /// The item is measured in square feet.
        /// </summary>
        [EnumMember(Value = "SQUARE_FEET")]
        SQUARE_FEET = 13,

        /// <summary>
        /// The item is measured in square inches.
        /// </summary>
        [EnumMember(Value = "SQUARE_INCHES")]
        SQUARE_INCHES = 14,

        /// <summary>
        /// The item is measured in gallons.
        /// </summary>
        [EnumMember(Value = "GALLONS")]
        GALLONS = 15,

        /// <summary>
        /// The item is measured in pints.
        /// </summary>
        [EnumMember(Value = "PINTS")]
        PINTS = 16,

        /// <summary>
        /// The item is measured in quarts.
        /// </summary>
        [EnumMember(Value = "QUARTS")]
        QUARTS = 17,

        /// <summary>
        /// The item is measured in fluid ounces.
        /// </summary>
        [EnumMember(Value = "FLUID_OUNCES")]
        FLUID_OUNCES = 18,

        /// <summary>
        /// The item is measured in liters.
        /// </summary>
        [EnumMember(Value = "LITERS")]
        LITERS = 19,

        /// <summary>
        /// The item is measured in cubic meters.
        /// </summary>
        [EnumMember(Value = "CUBIC_METERS")]
        CUBIC_METERS = 20,

        /// <summary>
        /// The item is measured in cubic feet.
        /// </summary>
        [EnumMember(Value = "CUBIC_FEET")]
        CUBIC_FEET = 21,

        /// <summary>
        /// The item is measured in cubic inches.
        /// </summary>
        [EnumMember(Value = "CUBIC_INCHES")]
        CUBIC_INCHES = 22,

        /// <summary>
        /// The item is measured in cubic centimeters.
        /// </summary>
        [EnumMember(Value = "CUBIC_CENTIMETERS")]
        CUBIC_CENTIMETERS = 23,

        /// <summary>
        /// The item is measured by count.
        /// </summary>
        [EnumMember(Value = "COUNT")]
        COUNT = 24,
    }

}
