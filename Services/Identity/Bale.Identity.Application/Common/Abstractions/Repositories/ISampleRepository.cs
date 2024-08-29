
using Bale.Identity.Domain.Samples;

namespace Bale.Identity.Application.Common.Abstractions.Repositories;

public interface ISampleRepository : IGenericRepository<Sample>
{
    public Task Test();
}
