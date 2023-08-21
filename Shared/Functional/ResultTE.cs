using System.Diagnostics.CodeAnalysis;

namespace Shared.Functional;

// Result of an operation that returns a value on success or returns an error on fail
public struct Result<TError, TSuccess>
{
    public Result() : this(default, default) { }

    private Result(TError? error, TSuccess? success)
    {
        if ((error is not null && success is not null) || (error is null && success is null))
        {
            throw new ArgumentException();
        }

        ErrorContent = error;
        SuccessContent = success;
        IsSuccess = success is not null;
    }

    public static Result<TError, TSuccess> Fail(TError error) => new Result<TError, TSuccess>(error, default);
    public static Result<TError, TSuccess> Success(TSuccess success) => new Result<TError, TSuccess>(default, success);

    [MemberNotNullWhen(true, nameof(ErrorContent))]
    [MemberNotNullWhen(false, nameof(SuccessContent))]
    internal bool IsFail => !IsSuccess;
    [MemberNotNullWhen(false, nameof(ErrorContent))]
    [MemberNotNullWhen(true, nameof(SuccessContent))]
    internal bool IsSuccess { get; }
    internal TError? ErrorContent { get; }
    internal TSuccess? SuccessContent { get; }
}
