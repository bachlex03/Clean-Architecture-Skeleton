using Microsoft.AspNetCore.Mvc;
using Bale.Identity.Domain.Common.Abstractions;

namespace Bale.Identity.Api.Common.Extensions;
public static class ResultExtension
{
    public static IActionResult Match<TResponse>(this Result<TResponse> result, Func<TResponse, IActionResult> onSuccess, Func<Result<TResponse>, IActionResult> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Response!) : onFailure(result);
    }
}
