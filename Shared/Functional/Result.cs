namespace Shared.Functional;

// Result of an operation that has no return value on success and returns no error details on fail
public struct Result
{
    public Result() : this(false) { }

    private Result(bool isSuccess) => IsSuccess = isSuccess;

    public static readonly Result Fail = new Result(false);
    public static readonly Result Success = new Result(true);

    internal bool IsFail => !IsSuccess;
    internal bool IsSuccess { get; }
}
