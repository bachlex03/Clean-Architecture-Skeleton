
using Bale.Identity.Application.Common.Abstractions.Messaging;
using Bale.Identity.Constract.Sample;

namespace Bale.Identity.Application.Sample.Commands;
public record CreateSampleCommand(string Email, string Name) : ICommand<CreateSampleResponse> { }

