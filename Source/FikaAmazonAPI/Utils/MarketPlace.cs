using FikaAmazonAPI.AmazonSpApiSDK.Models.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using static FikaAmazonAPI.ConstructFeed.BaseXML;

namespace FikaAmazonAPI.Utils
{
    public class MarketPlace
    {

        public string ID { get; set; }
        public Region Region { get; set; }

        public Country Country { get; set; }
        public BaseCurrencyCode CurrencyCode { get; set; }

        private MarketPlace(string id, Region region, Country country, BaseCurrencyCode currencyCode)
        {
            ID = id;
            Region = region;
            Country = country;
            CurrencyCode = currencyCode;
        }

        [JsonConstructorAttribute]
        public MarketPlace() { }

        public static MarketPlace GetMarketPlaceByID(string id)
        {
            var marketplace = _allMarketplaces.FirstOrDefault(a => a.ID == id);
            if (marketplace == null)
                throw new AmazonInvalidInputException($"InvalidInput, MarketPlace or MarketPlaceID cannot be null for both!");

            return marketplace;
        }

        public static MarketPlace GetMarketplaceByCountryCode(string countryCode)
        {
            return _allMarketplaces.FirstOrDefault(a => a.Country.Code == countryCode);
        }

        //https://developer-docs.amazon.com/sp-api/docs/marketplace-ids

        //NorthAmerica
        public static readonly MarketPlace US = new MarketPlace("ATVPDKIKX0DER", Region.NorthAmerica, Country.US, BaseCurrencyCode.USD);
        public static readonly MarketPlace Canada = new MarketPlace("A2EUQ1WTGCTBG2", Region.NorthAmerica, Country.CA, BaseCurrencyCode.CAD);
        public static readonly MarketPlace Mexico = new MarketPlace("A1AM78C64UM0Y8", Region.NorthAmerica, Country.MX, BaseCurrencyCode.MXN);
        public static readonly MarketPlace Brazil = new MarketPlace("A2Q3Y263D00KWC", Region.NorthAmerica, Country.BR, BaseCurrencyCode.BRL);

        //Europe
        public static readonly MarketPlace Spain = new MarketPlace("A1RKKUPIHCS9HS", Region.Europe, Country.ES, BaseCurrencyCode.EUR);
        public static readonly MarketPlace UnitedKingdom = new MarketPlace("A1F83G8C2ARO7P", Region.Europe, Country.GB, BaseCurrencyCode.GBP);
        public static readonly MarketPlace France = new MarketPlace("A13V1IB3VIYZZH", Region.Europe, Country.FR, BaseCurrencyCode.EUR);
        public static readonly MarketPlace Belgium = new MarketPlace("AMEN7PMS3EDWL", Region.Europe, Country.BE, BaseCurrencyCode.EUR);
        public static readonly MarketPlace Netherlands = new MarketPlace("A1805IZSGTT6HS", Region.Europe, Country.NL, BaseCurrencyCode.EUR);
        public static readonly MarketPlace Germany = new MarketPlace("A1PA6795UKMFR9", Region.Europe, Country.DE, BaseCurrencyCode.EUR);
        public static readonly MarketPlace Italy = new MarketPlace("APJ6JRA9NG5V4", Region.Europe, Country.IT, BaseCurrencyCode.EUR);
        public static readonly MarketPlace Sweden = new MarketPlace("A2NODRKZP88ZB9", Region.Europe, Country.SE, BaseCurrencyCode.SEK);
        public static readonly MarketPlace Egypt = new MarketPlace("ARBP9OOSHTCHU", Region.Europe, Country.EG, BaseCurrencyCode.EGP);
        public static readonly MarketPlace Poland = new MarketPlace("A1C3SOZRARQ6R3", Region.Europe, Country.PL, BaseCurrencyCode.PLN);
        public static readonly MarketPlace Turkey = new MarketPlace("A33AVAJ2PDY3EV", Region.Europe, Country.TR, BaseCurrencyCode.TRY);
        public static readonly MarketPlace UnitedArabEmirates = new MarketPlace("A2VIGQ35RCS4UG", Region.Europe, Country.AE, BaseCurrencyCode.AED);
        public static readonly MarketPlace India = new MarketPlace("A21TJRUUN4KGV", Region.Europe, Country.IN, BaseCurrencyCode.INR);
        public static readonly MarketPlace SaudiArabia = new MarketPlace("A17E79C6D8DWNP", Region.Europe, Country.SA, BaseCurrencyCode.SAR);
        public static readonly MarketPlace SouthAfrica = new MarketPlace("AE08WJ6YKNBMC", Region.Europe, Country.ZA, BaseCurrencyCode.ZAR);
        public static readonly MarketPlace Ireland = new MarketPlace("A28R8C7NBKEWEA", Region.Europe, Country.IE, BaseCurrencyCode.EUR);


        //FarEast
        public static readonly MarketPlace Singapore = new MarketPlace("A19VAU5U5O7RUS", Region.FarEast, Country.SG, BaseCurrencyCode.SGD);
        public static readonly MarketPlace Australia = new MarketPlace("A39IBJ37TRP1C6", Region.FarEast, Country.AU, BaseCurrencyCode.AUD);
        public static readonly MarketPlace Japan = new MarketPlace("A1VC38T7YXB528", Region.FarEast, Country.JP, BaseCurrencyCode.JPY);


        private static readonly IReadOnlyList<MarketPlace> _allMarketplaces = new[]
       {
            // NorthAmerica
            US, Canada, Mexico, Brazil,
            // Europe
            Spain, UnitedKingdom, France, Belgium,
            Netherlands, Germany, Italy, Sweden,
            Egypt, Poland, Turkey, UnitedArabEmirates,
            India, SaudiArabia, SouthAfrica, Ireland,
            // FarEast
            Singapore, Australia, Japan
        };

    }
}
