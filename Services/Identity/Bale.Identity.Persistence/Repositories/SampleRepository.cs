
using Bale.Identity.Application.Common.Abstractions.Repositories;
using Bale.Identity.Domain.Samples;

namespace Bale.Identity.Persistence.Repositories;

public class SampleRepository : GenericRepository<Sample>, ISampleRepository
{
    public SampleRepository(IMongoDbContext dbContext) : base(dbContext)
    {
    }

    public Task Test()
    {
        throw new NotImplementedException();
    }
}
