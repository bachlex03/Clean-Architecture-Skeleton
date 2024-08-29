
using Bale.Identity.Application.Common.Abstractions.Repositories;
using Bale.Identity.Persistence.DbSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Bale.Identity.Persistence;

public class ApplicationDbContext : IMongoDbContext
{
    private MongoClient Client { get; set; }
    private IMongoDatabase Database { get; set; }
    public ApplicationDbContext(IOptions<MongoDbSettings> mongoDbSettings)
    { 
        Client = new MongoClient(mongoDbSettings.Value.connectionString);
        Database = Client.GetDatabase(mongoDbSettings.Value.DatabaseName);
    }

    public IClientSession GetCurrentTransactionSession()
    {
        throw new NotImplementedException();
    }

    public Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IMongoCollection<TEntity> GetCollection<TEntity>()
    {
        return Database.GetCollection<TEntity>(typeof(TEntity).Name);
    }

    public IMongoCollection<TEntity> GetCollection<TEntity>(string name)
    {
        return Database.GetCollection<TEntity>(name);
    }
}
