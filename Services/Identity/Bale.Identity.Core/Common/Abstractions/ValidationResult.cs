
using Bale.Identity.Core.Common.Errors;

namespace Bale.Identity.Core.Common.Abstractions;
public class ValidationResult<TResponse> : Result<TResponse>, IValidationResult
{
    public Error[] Errors { get; }
    public ValidationResult(Error[] errors) : base(false, default, Error.ValidationError)
    {
        Errors = errors;
    }

    public static ValidationResult<TResponse> withErrors(Error[] Errors) => new(Errors);
}
