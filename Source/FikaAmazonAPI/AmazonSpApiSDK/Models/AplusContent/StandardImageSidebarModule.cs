using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Two images, two paragraphs, two bulleted lists; one image is a sidebar thumbnail.</summary>
    public class StandardImageSidebarModule
    {
        [JsonProperty("headline")]
        public TextComponent Headline { get; set; }

        [JsonProperty("imageCaptionBlock")]
        public StandardImageCaptionBlock ImageCaptionBlock { get; set; }

        [JsonProperty("descriptionTextBlock")]
        public StandardTextBlock DescriptionTextBlock { get; set; }

        [JsonProperty("descriptionListBlock")]
        public StandardTextListBlock DescriptionListBlock { get; set; }

        [JsonProperty("sidebarImageTextBlock")]
        public StandardImageTextBlock SidebarImageTextBlock { get; set; }

        [JsonProperty("sidebarListBlock")]
        public StandardTextListBlock SidebarListBlock { get; set; }
    }
}
