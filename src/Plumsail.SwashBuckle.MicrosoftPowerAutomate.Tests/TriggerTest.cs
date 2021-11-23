using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Swashbuckle.MicrosoftExtensions.Tests;
using System.Net.Http;
using TestApi;
using Xunit;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Tests
{
    public class TriggerTest
    {
        private readonly HttpClient _client;

        public TriggerTest()
        {
            // Arrange
            var server = new TestServer
            (
                new WebHostBuilder().UseStartup<Startup>()
            );
            _client = server.CreateClient();
        }

        [Fact]
        public async void TriggerSubscriprion()
        {
            var swaggerDoc = await _client.GetSwaggerDocument();
            var msTrigger = swaggerDoc.Paths["/api/Trigger"].Post.VendorExtensions["x-ms-trigger"] as string;
            dynamic notificationContent = swaggerDoc.Paths["/api/Trigger"].VendorExtensions["x-ms-notification-content"];

            Assert.Equal("single", msTrigger);
            Assert.Equal("TriggerFriendlyName", (string)notificationContent.description);
            Assert.Equal("#/definitions/TriggerAnswerModel", (string)notificationContent.schema["$ref"]);

            Assert.NotNull(swaggerDoc.Definitions["TriggerAnswerModel"]);
        }
    }
}
