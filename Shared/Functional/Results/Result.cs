using System.Diagnostics.CodeAnalysis;

namespace Shared.Functional.Results;

public readonly struct Result<TError, TSuccess>
{
    public Result() : this(false, default, default) { }

    private Result(bool isSuccess, TError? error, TSuccess? value)
    {
        IsSuccess = isSuccess;
        FailureContent = error;
        SuccessContent = value;
    }

    public static Result<TError, TSuccess> Failure(TError error) => new Result<TError, TSuccess>(false, error, default);
    public static Result<TError, TSuccess> Success(TSuccess success) => new Result<TError, TSuccess>(true, default, success);


    public static implicit operator Result<TError, TSuccess>(TError error) => Failure(error);

    public static implicit operator Result<TError, TSuccess>(TSuccess value) => Success(value);


    [MemberNotNullWhen(true, nameof(FailureContent))]
    [MemberNotNullWhen(false, nameof(SuccessContent))]
    internal bool IsFail => !IsSuccess;
    [MemberNotNullWhen(false, nameof(FailureContent))]
    [MemberNotNullWhen(true, nameof(SuccessContent))]
    internal bool IsSuccess { get; }
    internal TError? FailureContent { get; }
    internal TSuccess? SuccessContent { get; }
}
