using System.Collections.Generic;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities;

public class ConnectorMetadataModel
{
    public string Website { get; }
    public string PrivacyPolicy { get; }
    public IEnumerable<string> Categories { get; }

    public ConnectorMetadataModel(string website, string privacyPolicy, IEnumerable<string> categories)
    {
        Website = website;
        PrivacyPolicy = privacyPolicy;
        Categories = categories;
    }
}