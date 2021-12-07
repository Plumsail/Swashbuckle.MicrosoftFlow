using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;

namespace TestApi.Models
{
    public class CallbackUrlAttributeClass
    {

        [CallbackUrl]
        [Metadata(visibility: VisibilityType.Internal)]
        public string CallbackUrl { get; }
    }
}
