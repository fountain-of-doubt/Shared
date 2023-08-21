using System.Diagnostics.CodeAnalysis;

namespace Shared.Functional;

// Result of an operation that has no return value on success but returns error details on fail
public readonly struct Result<TError>
{
    public Result() : this(default) { }

    private Result(TError? error)
    {
        IsSuccess = error is not null;
        ErrorContent = error;
    }

    public static Result<TError> Fail(TError error) => new(error);
    public static readonly Result<TError> Success = new(default);

    public static implicit operator Result<TError>(TError error) => error is null ? Success : Fail(error);

    [MemberNotNullWhen(true, nameof(ErrorContent))]
    internal bool IsFail => !IsSuccess;
    [MemberNotNullWhen(false, nameof(ErrorContent))]
    internal bool IsSuccess { get; }
    internal TError? ErrorContent { get; }
}
