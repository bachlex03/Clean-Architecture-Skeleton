using Bale.Identity.Application.Common.Abstractions.Messaging;
using Bale.Identity.Application.Common.Abstractions.Repositories;
using Bale.Identity.Application.Samples.Commands;
using Bale.Identity.Constract.Samples;
using Bale.Identity.Domain.Common.Abstractions;
using Bale.Identity.Domain.Samples;

namespace Bale.Identity.Application.Samples.Command;
internal class CreateSampleCommandHandler : ICommandHandler<CreateSampleCommand, CreateSampleResponse>
{
    private readonly ISampleRepository _sampleRepository;

    public CreateSampleCommandHandler(ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
    }

    public async Task<Result<CreateSampleResponse>> Handle(CreateSampleCommand request, CancellationToken cancellationToken)
    {
        var newSample = new Sample() { Email = request.Email, Name = request.Name };

        var data = await _sampleRepository.InsertAsync(newSample, cancellationToken);
        
        var response = new CreateSampleResponse(data.Email, data.Name);

        return Result<CreateSampleResponse>.Success(response);

        //return Result<CreateSampleResponse>.Failure(SampleErrors.SampleError);

        //return true;
    }
}
