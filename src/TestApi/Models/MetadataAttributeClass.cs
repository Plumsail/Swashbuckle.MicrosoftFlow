using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using System.Text.Json.Serialization;

namespace TestApi.Models
{
    public class MetadataAttributeClass
    {
        //[JsonProperty("customName")]
        [JsonPropertyName("customName")]
        [Metadata("Friendly", "Description", VisibilityType.Advanced)]
        public string Name { get; }

        [CallbackUrl]
        [Metadata(visibility: VisibilityType.Internal)]
        public string CallbackUrl { get; }

        public MetadataAttributeClass(string name)
        {
            Name = name;
        }
    }
}