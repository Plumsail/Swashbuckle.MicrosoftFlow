using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities;
using System.Collections.Generic;

namespace TestApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(l => l.AddDebug());

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
                c.GenerateMicrosoftExtensions(FilePicker,
                     new ConnectorMetadataModel("http://www.example.com", "http://www.example.com/privacy", new [] { "Example", "Example2" }));
            });
            //services.AddSwaggerGenNewtonsoftSupport();
        }

        private FilePickerCapabilityModel FilePicker =>
            new(
                new FilePickerOperationModel("InitialOperation", null),
                new FilePickerOperationModel("BrowsingOperation", new Dictionary<string, string> { { "Id", "Id" } }),
                "Name",
                "IsFolder",
                "MediaType"
            );


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger(c => c.SerializeAsV2 = true);
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}