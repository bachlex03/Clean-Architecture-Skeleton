
using Bale.Identity.Application.Common.Abstractions.Messaging;
using Bale.Identity.Constract.Samples;

namespace Bale.Identity.Application.Samples.Commands;
public record CreateSampleCommand(string Email, string Name) : ICommand<CreateSampleResponse> { }

