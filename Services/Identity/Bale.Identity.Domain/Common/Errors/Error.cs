namespace Bale.Identity.Domain.Common.Errors;
public class Error
{
    public string Code { get; }
    public string Message { get; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error None => new("None.Error", "None error");

    public static Error ValidationError => new("Validation.Error", "Validation error");
    public static Error BadRequest(string code, string message) => new(code, message);
}
