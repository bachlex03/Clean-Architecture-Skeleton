
using Bale.Identity.Application.Common.Abstractions.Repositories;
using Bale.Identity.Persistence.DbSettings;
using Bale.Identity.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bale.Identity.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        // Register instance of MongoDbSettings to be used in ApplicationDbContext through IOptions
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

        // 
        services.AddScoped<IMongoDbContext, ApplicationDbContext>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ISampleRepository, SampleRepository>();

        return services;
    }
}
