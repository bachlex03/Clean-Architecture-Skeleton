namespace Bale.Identity.Core.Common.Errors;
internal class SampleErrors
{
    public static Error SampleError => Error.BadRequest("Sample.Error", "Sample error");
}
