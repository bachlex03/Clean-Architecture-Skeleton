using Bale.Identity.Core.Common.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Bale.Identity.Api.Controllers;
public class ApiController : ControllerBase
{
    protected IActionResult HandleFailure<TResponse>(Result<TResponse> result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException("Result is not a failure");
        }

        try
        {
            IValidationResult validationResult = (IValidationResult)result;

            HttpContext.Items.Add("errors", validationResult.Errors);

            return BadRequest(Problem(title: "Validation error").Value);
        }
        catch (InvalidCastException)
        {
            HttpContext.Items.Add("error", result.Error);

            return BadRequest(Problem(title: "Bad request").Value);
        }
    }
}
