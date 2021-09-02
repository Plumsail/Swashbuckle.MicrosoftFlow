using Newtonsoft.Json;

namespace SwashBuckle.MicrosoftExtensions.VendorExtensionEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal class NotificationContentModel
    {

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("schema")]
        public SchemaModel Schema { get; set; }

    }
}
