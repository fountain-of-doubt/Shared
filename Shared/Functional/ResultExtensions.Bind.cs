namespace Shared.Functional;

public static partial class AsyncResultExtensions
{
    public static Result<TError, TOut> Bind<TError, TSuccess, TOut>(in this Result<TError, TSuccess> result, Func<TSuccess, Result<TError, TOut>> bind)
        => result.IsSuccess
            ? bind(result.SuccessContent)
            : Result<TError, TOut>.Failure(result.FailureContent);
}
