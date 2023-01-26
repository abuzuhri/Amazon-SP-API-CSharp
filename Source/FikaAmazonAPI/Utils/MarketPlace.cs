using System.Collections.Generic;
using System.Linq;

namespace FikaAmazonAPI.Utils
{
    public class MarketPlace
    {

        public string ID { get; set; }
        public Region Region { get; set; }

        public Country Country { get; set; }

        private MarketPlace(string id, Region region, Country country)
        {
            ID = id;
            Region = region;
            Country = country;
        }

        public static MarketPlace GetMarketPlaceByID(string id)
        {
            var list = new List<MarketPlace>();
            //NorthAmerica
            list.Add(US); list.Add(Canada); list.Add(Mexico); list.Add(Brazil);
            //Europe
            list.Add(Spain); list.Add(UnitedKingdom); list.Add(France); list.Add(Belgium);
            list.Add(Netherlands); list.Add(Germany); list.Add(Italy); list.Add(Sweden);
            list.Add(Egypt); list.Add(Poland); list.Add(Turkey); list.Add(UnitedArabEmirates);
            list.Add(India); list.Add(SaudiArabia);
            //FarEast
            list.Add(Singapore); list.Add(Australia); list.Add(Japan);

            return list.FirstOrDefault(a => a.ID == id);
        }

        public static MarketPlace GetMarketplaceByCountryCode(string countryCode)
        {
            var list = new List<MarketPlace>();
            //NorthAmerica
            list.Add(US); list.Add(Canada); list.Add(Mexico); list.Add(Brazil);
            //Europe
            list.Add(Spain); list.Add(UnitedKingdom); list.Add(France); list.Add(Belgium);
            list.Add(Netherlands);list.Add(Germany); list.Add(Italy); list.Add(Sweden); 
            list.Add(Egypt);list.Add(Poland); list.Add(Turkey); list.Add(UnitedArabEmirates); 
            list.Add(India); list.Add(SaudiArabia);
            //FarEast
            list.Add(Singapore); list.Add(Australia); list.Add(Japan);
            return list.FirstOrDefault(a => a.Country.Code == countryCode);
        }

        //https://developer-docs.amazon.com/sp-api/docs/marketplace-ids

        //NorthAmerica
        public static MarketPlace US { get { return new MarketPlace("ATVPDKIKX0DER", Region.NorthAmerica, Country.US); } }
        public static MarketPlace Canada { get { return new MarketPlace("A2EUQ1WTGCTBG2", Region.NorthAmerica, Country.CA); } }
        public static MarketPlace Mexico { get { return new MarketPlace("A1AM78C64UM0Y8", Region.NorthAmerica, Country.MX); } }
        public static MarketPlace Brazil { get { return new MarketPlace("A2Q3Y263D00KWC", Region.NorthAmerica, Country.BR); } }

        //Europe
        public static MarketPlace Spain { get { return new MarketPlace("A1RKKUPIHCS9HS", Region.Europe, Country.ES); } }
        public static MarketPlace UnitedKingdom { get { return new MarketPlace("A1F83G8C2ARO7P", Region.Europe, Country.GB); } }
        public static MarketPlace France { get { return new MarketPlace("A13V1IB3VIYZZH", Region.Europe, Country.FR); } }
        public static MarketPlace Belgium { get { return new MarketPlace("AMEN7PMS3EDWL", Region.Europe, Country.BE); } }
        public static MarketPlace Netherlands { get { return new MarketPlace("A1805IZSGTT6HS", Region.Europe, Country.NL); } }
        public static MarketPlace Germany { get { return new MarketPlace("A1PA6795UKMFR9", Region.Europe, Country.DE); } }
        public static MarketPlace Italy { get { return new MarketPlace("APJ6JRA9NG5V4", Region.Europe, Country.IT); } }
        public static MarketPlace Sweden { get { return new MarketPlace("A2NODRKZP88ZB9", Region.Europe, Country.SE); } }
        public static MarketPlace Egypt { get { return new MarketPlace("ARBP9OOSHTCHU", Region.Europe, Country.EG); } }
        public static MarketPlace Poland { get { return new MarketPlace("A1C3SOZRARQ6R3", Region.Europe, Country.PL); } }
        public static MarketPlace Turkey { get { return new MarketPlace("A33AVAJ2PDY3EV", Region.Europe, Country.TR); } }
        public static MarketPlace UnitedArabEmirates { get { return new MarketPlace("A2VIGQ35RCS4UG", Region.Europe, Country.AE); } }
        public static MarketPlace India { get { return new MarketPlace("A21TJRUUN4KGV", Region.Europe, Country.IN); } }
        public static MarketPlace SaudiArabia { get { return new MarketPlace("A17E79C6D8DWNP", Region.Europe, Country.SA); } }

        //FarEast
        public static MarketPlace Singapore { get { return new MarketPlace("A19VAU5U5O7RUS", Region.FarEast, Country.SG); } }
        public static MarketPlace Australia { get { return new MarketPlace("A39IBJ37TRP1C6", Region.FarEast, Country.AU); } }
        public static MarketPlace Japan { get { return new MarketPlace("A1VC38T7YXB528", Region.FarEast, Country.JP); } }






    }






}
