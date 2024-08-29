
using Bale.Identity.Domain.Common.Errors;

namespace Bale.Identity.Domain.Common.Abstractions;
public interface IValidationResult
{
    public static readonly Error ValidationError = new Error("Validation Error", "Validation error");

    Error[] Errors { get; }
}
