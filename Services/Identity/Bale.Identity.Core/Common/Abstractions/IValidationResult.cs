
using Bale.Identity.Core.Common.Errors;

namespace Bale.Identity.Core.Common.Abstractions;
public interface IValidationResult
{
    public static readonly Error ValidationError = new Error("Validation Error", "Validation error");

    Error[] Errors { get; }
}
