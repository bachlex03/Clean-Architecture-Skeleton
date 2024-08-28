namespace Bale.Identity.Core.Common.Errors;
public class SampleErrors
{
    public static Error SampleError => Error.BadRequest("Sample.Error", "Sample error");
}
