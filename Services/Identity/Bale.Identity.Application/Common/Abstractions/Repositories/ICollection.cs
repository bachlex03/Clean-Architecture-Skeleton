
using MongoDB.Driver;

namespace Bale.Identity.Application.Common.Abstractions.Repositories;

public interface ICollection
{
    IMongoCollection<TEntity> GetCollection<TEntity>();
    IMongoCollection<TEntity> GetCollection<TEntity>(string name);
}
