﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using SwashBuckle.MicrosoftExtensions.Extensions;
using SwashBuckle.MicrosoftExtensions.VendorExtensionEntities;

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
                c.GenerateMicrosoftExtensions(FilePicker);
            });
        }

        private FilePickerCapabilityModel FilePicker =>
            new FilePickerCapabilityModel
            (
                new FilePickerOperationModel("InitialOperation", null),
                new FilePickerOperationModel("BrowsingOperation", new Dictionary<string, string> {{"Id", "Id"}}),
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