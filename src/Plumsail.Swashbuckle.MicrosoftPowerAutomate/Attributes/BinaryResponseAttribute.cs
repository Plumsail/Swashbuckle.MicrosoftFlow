using System;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BinaryResponseAttribute : Attribute
    {
        public int StatusCode { get; }
        public string Summary { get; }
        public string ContentType { get; }
        public string Description { get; }


        public BinaryResponseAttribute(int statusCode, string summary, string contentType, string description = null)
        {
            StatusCode = statusCode;
            Summary = summary;
            ContentType = contentType;
            Description = description;
        }
    }
}
