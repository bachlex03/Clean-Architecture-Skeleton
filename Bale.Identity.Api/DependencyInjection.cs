
using Asp.Versioning;
using Bale.Identity.Api.OpenApi;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bale.Identity.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services) {
        
        services.AddVersioning();

        services.AddSwaggerExtentions();

        return services;
    }

    public static IServiceCollection AddSwaggerExtentions(this IServiceCollection services)
    {
       services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigurationOptions>();

        return services;
    }

    public static IServiceCollection AddVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            // this is the default version, if the client doesn't specify a version, this is the version that will be used
            options.AssumeDefaultVersionWhenUnspecified = true;
            // because we have a default version, we need to specify the default version (1 is number version, 0 is minor version)
            options.DefaultApiVersion = new ApiVersion(1, 0);
            // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
            options.ReportApiVersions = true;
            // this is the reader that will read the version from the url segment (.../.../)
            options.ApiVersionReader = new UrlSegmentApiVersionReader();

            // this is the reader that will read the version from the query string (?v=...)
            // options.ApiVersionReader = new QueryStringApiVersionReader("v");

            // this is the reader that will read the version from the header (api-version: 1.0)
            // options.ApiVersionReader = new HeaderApiVersionReader("X-api-version");

            // this is the reader that will read the version from the accept header (Accept: application/json;v=1.0)
            // options.ApiVersionReader = new MediaTypeApiVersionReader("v");

            // combine the version reader, so it will read from the url segment, query string, header, and accept header
            // options.ApiVersionReader = ApiVersionReader.Combine(
            //     new UrlSegmentApiVersionReader(),
            //     new QueryStringApiVersionReader("v"),
            //     new HeaderApiVersionReader("X-api-version"),
            //     new MediaTypeApiVersionReader("v")
            // );
        }).AddApiExplorer(options =>
        {
            // this is the group name format, it will format the group name (v1.0) to ('v'VVV) => 'v1.0
            options.GroupNameFormat = "'v'VVV";
            // this is the group name selector, it will select the group name based on the version (only necsesary with url segment)
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
}
