using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StudioAdminWeb.Helppers
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description)  //Documenta el swagger
        {
            var info = new OpenApiInfo()
            {
                Title = "Studio Admin",
                Description = description.ApiVersion.ToString(),
            };
            if (description.IsDeprecated)
            {
                info.Description = "This Api version has been deprecated";
            }
            return info;
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        public void Configure(SwaggerGenOptions options)
        {
            Configure(options);
        }
    }
}
