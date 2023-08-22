namespace Shared.Functional;

public static partial class ResultExtensions
{
    public static Task<Result<TError, TOut>> OnSuccess<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task<Result<TError, TOut>>> bind, bool configureAwait = false)
        => taskResult.Bind(bind, configureAwait);

    public static Task<Result<TError, TOut>> OnSuccess<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Result<TError, TOut>> bind, bool configureAwait = false)
        => taskResult.Bind(bind, configureAwait);

    public static Task<Result<TError, TOut>> OnSuccess<TError, TSuccess, TOut>(this Result<TError, TSuccess> taskResult, Func<TSuccess, Task<Result<TError, TOut>>> bind, bool configureAwait = false)
        => taskResult.Bind(bind, configureAwait);


    public static Task<Result<TError, TOut>> OnSuccess<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> result, Func<TSuccess, Task<TOut>> map, bool configureAwait = false)
        => result.Map(map, configureAwait);

    public static Task<Result<TError, TOut>> OnSuccess<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> result, Func<TSuccess, TOut> map, bool configureAwait = false)
        => result.Map(map, configureAwait);

    public static Task<Result<TError, TOut>> OnSuccess<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, Task<TOut>> map, bool configureAwait = false)
        => result.Map(map, configureAwait);
}
