﻿
using Bale.Identity.Core.Common.Abstractions;
using Bale.Identity.Core.Common.Errors;
using FluentValidation;
using MediatR;

namespace Bale.Identity.Application.Common.Behaviors;
public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validator;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validator.Any())
        {
            return await next();
        }

        Error[] errors = _validator.Select(validator => validator.Validate(request))
        .SelectMany(validationResult => validationResult.Errors)
        .Where(validationFailure => validationFailure is not null)
        .Select(failure => new Error(failure.PropertyName, failure.ErrorMessage))
        .Distinct()
        .ToArray();

        if (errors.Any())
        {
            return CreateValidationResult<TResponse>(errors);
        }

        return await next();
    }

    private static TResult CreateValidationResult<TResult>(Error[] errors) where TResult : class
    {
        if (typeof(TResult) == typeof(Result))
        {
            return (ValidationResult<TResult>.withErrors(errors) as TResult)!;
        }

        object validationResult =
            typeof(ValidationResult<>).GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
            .GetMethod(nameof(ValidationResult<TResult>.withErrors))!.Invoke(null, new object?[] { errors })!;

        return (TResult)validationResult;
    }
}
