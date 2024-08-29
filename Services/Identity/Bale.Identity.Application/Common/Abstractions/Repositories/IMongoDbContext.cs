
using MongoDB.Driver;

namespace Bale.Identity.Application.Common.Abstractions.Repositories;

public interface IMongoDbContext: ICollection
{
    IClientSession GetCurrentTransactionSession();
    Task BeginTransactionAsync(CancellationToken cancellationToken = default); 
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
}
