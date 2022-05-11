using System.Xml.Serialization;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public partial class ProductImageMessage
    {
        public string SKU { get; set; }
        public ImageType ImageType { get; set; }
        public string ImageLocation { get; set; }
    }

    public enum ImageType
    {
        Main,
        Swatch,
        BKLB,
        PT1,
        PT2,
        PT3,
        PT4,
        PT5,
        PT6,
        PT7,
        PT8,
        Search,
        PM01,
        MainOfferImage,
        OfferImage1,
        OfferImage2,
        OfferImage3,
        OfferImage4,
        OfferImage5,
        PFEE,
        PFUK,
        PFDE,
        PFFR,
        PFIT,
        PFES,
        EEGL,
        PT98,
        PT99,
        ELFL
    }
}
