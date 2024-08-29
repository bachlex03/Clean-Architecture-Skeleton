using Bale.Identity.Domain.Common.Errors;

namespace Bale.Identity.Domain.Common.Abstractions;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
}

public class Result<TResponse> : Result
{
    public TResponse? Response { get; }

    public Result(bool isSuccess, TResponse? response, Error error) : base(isSuccess, error)
    {
        Response = response;
    }

    public static Result<TResponse> Success(TResponse response) => new(true, response, Error.None);
    public static Result<TResponse> Failure(Error error) => new(false, default!, error);
    public static implicit operator Result<TResponse>(bool result) => new(true, default, Error.None);
}
