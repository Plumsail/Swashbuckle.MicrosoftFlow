using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Swashbuckle.MicrosoftExtensions.Tests;
using System.Net.Http;
using TestApi;
using Xunit;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Tests
{
    public class BinaryResponseTest
    {
        private readonly HttpClient _client;

        public BinaryResponseTest()
        {
            // Arrange
            var server = new TestServer
            (
                new WebHostBuilder().UseStartup<Startup>()
            );
            _client = server.CreateClient();
        }

        [Fact]
        public async void BinaryResponse()
        {
            var swaggerDoc = await _client.GetSwaggerDocument();

            var response = swaggerDoc.Paths["/api/BinaryResponse"].Get.Responses["200"];

            Assert.Equal("BinaryResponseDescription", response.Description);
            Assert.Equal("binary", response.Schema.Format);
            Assert.Equal("string", response.Schema.Type);
            Assert.Equal("BinaryResponseDescription", response.Schema.Description);
            Assert.Equal("BinaryResponseSummary", response.Schema.Title);
        }

    }
}
