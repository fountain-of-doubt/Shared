namespace Shared.Functional;

public static partial class ResultExtensions
{
    public static Task<Result<TError, TOut>> OnSuccess<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task<Result<TError, TOut>>> bind)
        => taskResult.Bind(bind);

    public static Task<Result<TError, TOut>> OnSuccess<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Result<TError, TOut>> bind)
        => taskResult.Bind(bind);

    public static Task<Result<TError, TOut>> OnSuccess<TError, TSuccess, TOut>(this Result<TError, TSuccess> taskResult, Func<TSuccess, Task<Result<TError, TOut>>> bind)
        => taskResult.Bind(bind);


    public static Task<Result<TError, TOut>> OnSuccess<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> result, Func<TSuccess, Task<TOut>> map)
        => result.Map(map);

    public static Task<Result<TError, TOut>> OnSuccess<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> result, Func<TSuccess, TOut> map)
        => result.Map(map);

    public static Task<Result<TError, TOut>> OnSuccess<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, Task<TOut>> map)
        => result.Map(map);
}
