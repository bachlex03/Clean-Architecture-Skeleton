
using Bale.Identity.Domain.Common.Abstractions;
using MediatR;

namespace Bale.Identity.Application.Common.Abstractions.Messaging;
internal interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommand<TResponse> { }
