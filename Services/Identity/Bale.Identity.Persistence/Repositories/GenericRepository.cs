
using Bale.Identity.Application.Common.Abstractions.Repositories;
using Bale.Identity.Domain.Common.Primitives;
using MongoDB.Driver;

namespace Bale.Identity.Persistence.Repositories;
public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : Entity
{
    private readonly IMongoCollection<TEntity> _collection;
    private readonly IMongoDbContext _dbContext;
    public GenericRepository(IMongoDbContext dbContext)
    {
        _dbContext = dbContext;
        _collection = dbContext.GetCollection<TEntity>();
    }

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);

        return entity;
    }

    public Task InsertManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateManyAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
