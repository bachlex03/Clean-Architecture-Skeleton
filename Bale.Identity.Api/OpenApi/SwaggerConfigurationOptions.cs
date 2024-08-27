using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Bale.Identity.Api.OpenApi;

public class SwaggerConfigurationOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public SwaggerConfigurationOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
       foreach(var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, OpenApiInfo(description));
        }

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    }

    static OpenApiInfo OpenApiInfo(ApiVersionDescription description)
    {
        var info = new OpenApiInfo
        {
            Title = "Identity Service",
            Version = description.ApiVersion.ToString(),
            Description = "There are APIs used for authentication and authorization",
            Contact = new OpenApiContact
            {
                Name = "Lê Xuân Bách",
                Email = "lxbachit03.working@gmail.com",
                Url = new Uri("https://github.com/bachlex03")
            },
            License = new OpenApiLicense
            {
                Name = "Use under LICX"
            }
        };

        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }

        

        return info;
    }
}
