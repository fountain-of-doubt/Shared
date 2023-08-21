using System.Diagnostics.CodeAnalysis;

namespace Shared.Functional;

// Result of an operation that returns a value on success or returns an error on fail
public readonly struct Result<TError, TSuccess>
{
    public Result() : this(false, default, default) { }

    private Result(bool isSuccess, TError? error, TSuccess? value)
    {
        IsSuccess = isSuccess;
        ErrorContent = error;
        SuccessContent = value;
    }

    public static Result<TError, TSuccess> Fail(TError error) => new Result<TError, TSuccess>(false, error, default);
    public static Result<TError, TSuccess> Success(TSuccess success) => new Result<TError, TSuccess>(true, default, success);


    public static implicit operator Result<TError, TSuccess>(TError error) => Fail(error);

    public static implicit operator Result<TError, TSuccess>(TSuccess value) => Success(value);


    [MemberNotNullWhen(true, nameof(ErrorContent))]
    [MemberNotNullWhen(false, nameof(SuccessContent))]
    internal bool IsFail => !IsSuccess;
    [MemberNotNullWhen(false, nameof(ErrorContent))]
    [MemberNotNullWhen(true, nameof(SuccessContent))]
    internal bool IsSuccess { get; }
    internal TError? ErrorContent { get; }
    internal TSuccess? SuccessContent { get; }
}
