using System.Text.Json.Serialization;

namespace FikaAmazonAPI.Utils
{
    public class Country
    {
        [JsonConstructorAttribute]
        public Country() { }

        public string Code { get; set; }
        public string Name { get; set; }
        public string SellercentralURL { get; set; }
        public string VendorCentralURL { get; set; }
        public string AmazonlUrl { get; set; }

        private Country(string code, string name, string domain, string sellercentralUrl, string vendorCentralURL)
        {
            Code = code;
            Name = name;

            SellercentralURL = sellercentralUrl;
            VendorCentralURL = vendorCentralURL;

            AmazonlUrl = $"https://amazon.{domain}";
        }

        public static readonly Country US = new Country("US", "United States of America", "com", "https://sellercentral.amazon.com", "https://vendorcentral.amazon.ca");
        public static readonly Country CA = new Country("CA", "Canada", "ca", "https://sellercentral.amazon.ca", "https://vendorcentral.amazon.ca");
        public static readonly Country MX = new Country("MX", "Mexico", "com.mx", "https://sellercentral.amazon.com.mx", "https://vendorcentral.amazon.com.mx");
        public static readonly Country BR = new Country("BR", "Brazil", "com.br", "https://sellercentral.amazon.com.br", "https://vendorcentral.amazon.com.br");

        public static readonly Country ES = new Country("ES", "Spain", "es", "https://sellercentral-europe.amazon.com", "https://vendorcentral.amazon.es");
        public static readonly Country GB = new Country("GB", "United Kingdom", "co.uk", "https://sellercentral-europe.amazon.com", "https://vendorcentral.amazon.co.uk");
        public static readonly Country FR = new Country("FR", "France", "fr", "https://sellercentral-europe.amazon.com", "https://vendorcentral.amazon.fr");
        public static readonly Country BE = new Country("BE", "Belgium", "com.be", "https://sellercentral-europe.amazon.com", "https://vendorcentral.amazon.eu");
        public static readonly Country NL = new Country("NL", "Netherlands", "nl", "https://sellercentral.amazon.nl", "https://vendorcentral.amazon.nl");
        public static readonly Country DE = new Country("DE", "Germany", "de", "https://sellercentral-europe.amazon.com", "https://vendorcentral.amazon.de");
        public static readonly Country IT = new Country("IT", "Italy", "it", "https://sellercentral-europe.amazon.com", "https://vendorcentral.amazon.it");
        public static readonly Country SE = new Country("SE", "Sweden", "se", "https://sellercentral.amazon.se", "https://vendorcentral.amazon.se");
        public static readonly Country PL = new Country("PL", "Poland", "pl", "https://sellercentral.amazon.pl", "https://vendorcentral.amazon.pl");
        public static readonly Country EG = new Country("EG", "Egypt", "eg", "https://sellercentral.amazon.eg", "https://vendorcentral.amazon.me");
        public static readonly Country TR = new Country("TR", "Turkey", "com.tr", "https://sellercentral.amazon.com.tr", "https://vendorcentral.amazon.com.tr");
        public static readonly Country AE = new Country("AE", "United Arab Emirates", "ae", "https://sellercentral.amazon.ae", "https://vendorcentral.amazon.me");
        public static readonly Country IN = new Country("IN", "India", "in", "https://sellercentral.amazon.in", "https://www.vendorcentral.in");
        public static readonly Country SA = new Country("SA", "Saudi Arabia", "sa", "https://sellercentral.amazon.sa", "https://vendorcentral.amazon.me");
        public static readonly Country IE = new Country("IE", "Ireland", "ie", "https://sellercentral.amazon.ie", "https://vendorcentral.amazon.ie");


        public static readonly Country SG = new Country("SG", "Singapore", "sg", "https://sellercentral.amazon.sg", "https://vendorcentral.amazon.com.sg");
        public static readonly Country AU = new Country("AU", "Australia", "com.au", "https://sellercentral.amazon.com.au", "https://vendorcentral.amazon.com.au");
        public static readonly Country JP = new Country("JP", "Japan", "co.jp", "https://sellercentral.amazon.co.jp", "https://vendorcentral.amazon.co.jp");

        public static readonly Country ZA = new Country("ZA", "South Africa", "co.za", "https://sellercentral.amazon.co.za", "https://vendorcentral.amazon.co.za");
    }
}
