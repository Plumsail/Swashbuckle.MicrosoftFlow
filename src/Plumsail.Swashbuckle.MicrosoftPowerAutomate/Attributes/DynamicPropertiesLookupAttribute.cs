using System;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes
{
    /// <summary>
    /// Extends swagger definition with vendor extension: x-ms-dynamic-schema
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Method, Inherited = false)]
    public sealed class DynamicPropertiesLookupAttribute : Attribute
    {
        public string Parameters { get; }

        public string LookupOperation { get; }

        public string ItemValuePath { get; }

        public DynamicPropertiesLookupAttribute(string lookupOperation, string itemValuePath, string parameters = null)
        {
            LookupOperation = lookupOperation;
            ItemValuePath = itemValuePath;
            Parameters = parameters;
        }
    }
}
