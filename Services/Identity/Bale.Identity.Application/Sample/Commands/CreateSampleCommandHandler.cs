using Bale.Identity.Application.Common.Abstractions.Messaging;
using Bale.Identity.Application.Sample.Commands;
using Bale.Identity.Constract.Sample;
using Bale.Identity.Core.Common.Abstractions;

namespace Bale.Identity.Application.Sample.Command;
internal class CreateSampleCommandHandler : ICommandHandler<CreateSampleCommand, CreateSampleResponse>
{
    public Task<Result<CreateSampleResponse>> Handle(CreateSampleCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateSampleResponse(Email: request.Email, Name: request.Name);

        throw new Exception("test");
    }
}
