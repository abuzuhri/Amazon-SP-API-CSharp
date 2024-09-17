namespace FikaAmazonAPI.Utils
{
    public class Country
    {
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

        public static Country US { get { return new Country("US", "United States of America", "com", "https://sellercentral.amazon.com", "https://vendorcentral.amazon.ca"); } }
        public static Country CA { get { return new Country("CA", "Canada", "ca", "https://sellercentral.amazon.ca", "https://vendorcentral.amazon.ca"); } }
        public static Country MX { get { return new Country("MX", "Mexico", "com.mx", "https://sellercentral.amazon.com.mx", "https://vendorcentral.amazon.com.mx"); } }
        public static Country BR { get { return new Country("BR", "Brazil", "com.br", "https://sellercentral.amazon.com.br", "https://vendorcentral.amazon.com.br"); } }

        public static Country ES { get { return new Country("ES", "Spain", "es", "https://sellercentral-europe.amazon.com", "https://vendorcentral.amazon.es"); } }
        public static Country GB { get { return new Country("GB", "United Kingdom", "co.uk", "https://sellercentral-europe.amazon.com", "https://vendorcentral.amazon.co.uk"); } }
        public static Country FR { get { return new Country("FR", "France", "fr", "https://sellercentral-europe.amazon.com", "https://vendorcentral.amazon.fr"); } }
        public static Country BE { get { return new Country("BE", "Belgium", "com.be", "https://sellercentral-europe.amazon.com", "https://vendorcentral.amazon.eu"); } }
        public static Country NL { get { return new Country("NL", "Netherlands", "nl", "https://sellercentral.amazon.nl", "https://vendorcentral.amazon.nl"); } }
        public static Country DE { get { return new Country("DE", "Germany", "de", "https://sellercentral-europe.amazon.com", "https://vendorcentral.amazon.de"); } }
        public static Country IT { get { return new Country("IT", "Italy", "it", "https://sellercentral-europe.amazon.com", "https://vendorcentral.amazon.it"); } }
        public static Country SE { get { return new Country("SE", "Sweden", "se", "https://sellercentral.amazon.se", "https://vendorcentral.amazon.se"); } }
        public static Country PL { get { return new Country("PL", "Poland", "pl", "https://sellercentral.amazon.pl", "https://vendorcentral.amazon.pl"); } }
        public static Country EG { get { return new Country("EG", "Egypt", "eg", "https://sellercentral.amazon.eg", "https://vendorcentral.amazon.me"); } }
        public static Country TR { get { return new Country("TR", "Turkey", "com.tr", "https://sellercentral.amazon.com.tr", "https://vendorcentral.amazon.com.tr"); } }
        public static Country AE { get { return new Country("AE", "United Arab Emirates", "ae", "https://sellercentral.amazon.ae", "https://vendorcentral.amazon.me"); } }
        public static Country IN { get { return new Country("IN", "India", "in", "https://sellercentral.amazon.in", "https://www.vendorcentral.in"); } }
        public static Country SA { get { return new Country("SA", "Saudi Arabia", "sa", "https://sellercentral.amazon.sa", "https://vendorcentral.amazon.me"); } }



        public static Country SG { get { return new Country("SG", "Singapore", "sg", "https://sellercentral.amazon.sg", "https://vendorcentral.amazon.com.sg"); } }
        public static Country AU { get { return new Country("AU", "Australia", "com.au", "https://sellercentral.amazon.com.au", "https://vendorcentral.amazon.com.au"); } }
        public static Country JP { get { return new Country("JP", "Japan", "co.jp", "https://sellercentral.amazon.co.jp", "https://vendorcentral.amazon.co.jp"); } }

        public static Country ZA { get { return new Country("ZA", "South Africa", "co.za", "https://sellercentral.amazon.co.za", "https://vendorcentral.amazon.co.za"); } }
    }
}
