using System;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes
{

    /// <summary>
    /// Extends swagger definition with vendor extension: x-ms-dynamic-list
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    public sealed class DynamicListLookupAttribute : Attribute
    {
        /// <summary>
        /// Gets the parameter values to pass to the lookup operation
        /// (e.g., lookupOpParam={paramNameFromThisOperation}&amp;lookupOpParam2=hardcoded)
        /// </summary>
        public string Parameters { get; }

        /// <summary>
        /// Lookup operation ID, use swagger operation ID of action to call
        /// </summary>
        public string LookupOperation { get; }

        /// <summary>
        /// Backend value path  within object for further use.
        /// </summary>
        public string ItemValuePath { get; }

        /// <summary>
        /// Path to array where values are residing, if left empty base object will be parsed as array
        /// </summary>
        public string ItemsPath { get; }

        /// <summary>
        /// User facing value path, these values will show up for user to choose.
        /// </summary>
        public string ItemTitlePath { get; }

        /// <param name="lookupOperation">
        /// Lookup operation ID, use swagger operation ID of action to call
        /// </param>
        /// <param name="valuePath">
        /// Backend value path  within object for further use.
        /// </param>
        /// <param name="itemTitlePath">
        /// User facing value path, these values will show up for user to choose.
        /// </param>
        /// <param name="itemsPath">
        /// Path to array where values are residing, if left empty base object will be parsed as array
        /// </param>
        /// <param name="parameters">
        /// Gets the parameter values to pass to the lookup operation
        /// (e.g., lookupOpParam={paramNameFromThisOperation}&amp;lookupOpParam2=hardcoded)
        /// </param>
        public DynamicListLookupAttribute(string lookupOperation, string itemValuePath, string itemTitlePath, string itemsPath = null, string parameters = null)
        {
            LookupOperation = lookupOperation;
            Parameters = parameters;
            ItemsPath = itemsPath;
            ItemValuePath = itemValuePath;
            ItemTitlePath = itemTitlePath;
        }

    }
}