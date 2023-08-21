using System.Diagnostics.CodeAnalysis;

namespace Shared.Functional;

// Result of an operation that returns a value on success or returns an error on fail
public struct Result<TError, TSuccess>
{
    public Result() : this(default, default) { }

    private Result(TError? error, TSuccess? value)
    {
        if ((error is not null && value is not null) || (error is null && value is null))
        {
            throw new ArgumentException();
        }

        ErrorContent = error;
        SuccessContent = value;
        IsSuccess = value is not null;
    }

    public static Result<TError, TSuccess> Fail(TError error) => new Result<TError, TSuccess>(error, default);
    public static Result<TError, TSuccess> Success(TSuccess success) => new Result<TError, TSuccess>(default, success);


    public static explicit operator Result<TError, TSuccess>(TError error) => error is not null ? Fail(error) : throw new ArgumentNullException(nameof(error));
    public static explicit operator Result<TError, TSuccess>(TSuccess value) => value is not null ? Success(value) : throw new ArgumentNullException(nameof(value));

    [MemberNotNullWhen(true, nameof(ErrorContent))]
    [MemberNotNullWhen(false, nameof(SuccessContent))]
    internal bool IsFail => !IsSuccess;
    [MemberNotNullWhen(false, nameof(ErrorContent))]
    [MemberNotNullWhen(true, nameof(SuccessContent))]
    internal bool IsSuccess { get; }
    internal TError? ErrorContent { get; }
    internal TSuccess? SuccessContent { get; }
}
