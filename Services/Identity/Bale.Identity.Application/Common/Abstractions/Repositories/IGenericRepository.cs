
using Bale.Identity.Domain.Common.Primitives;


namespace Bale.Identity.Application.Common.Abstractions.Repositories;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task InsertManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateManyAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
}

