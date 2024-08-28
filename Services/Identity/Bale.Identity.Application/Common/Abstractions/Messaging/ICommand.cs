
using Bale.Identity.Core.Common.Abstractions;
using MediatR;

namespace Bale.Identity.Application.Common.Abstractions.Messaging;
internal interface ICommand<TResponse> : IRequest<Result<TResponse>> { }
