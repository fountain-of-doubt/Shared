using Shared.Functional.Results;

namespace Shared.Functional;

public static partial class ResultExtensions
{
    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, Task<TOut>> OnFailure, bool configureAwait = false)
        => taskResult.Match(OnSuccess, OnFailure, configureAwait);

    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, TOut> OnFailure, bool configureAwait = false)
        => taskResult.Match(OnSuccess, OnFailure, configureAwait);

    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, TOut> OnSuccess, Func<TError, Task<TOut>> OnFailure, bool configureAwait = false)
        => taskResult.Match(OnSuccess, OnFailure, configureAwait);

    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, TOut> OnSuccess, Func<TError, TOut> OnFailure, bool configureAwait = false)
        => taskResult.Match(OnSuccess, OnFailure, configureAwait);

    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, Task<TOut>> OnFailure, bool configureAwait = false)
        => result.Match(OnSuccess, OnFailure,configureAwait);

    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, TOut> OnFailure, bool configureAwait = false)
        => result.Match(OnSuccess, OnFailure,configureAwait);

    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, TOut> OnSuccess, Func<TError, Task<TOut>> OnFailure, bool configureAwait = false)
        => result.Match(OnSuccess, OnFailure, configureAwait);



    public static Task Handle<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
        => taskResult.Match(OnSuccess, OnFailure, configureAwait);

    public static Task Handle<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure, bool configureAwait = false)
        => taskResult.Match(OnSuccess, OnFailure, configureAwait);

    public static Task Handle<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
        => taskResult.Match(OnSuccess, OnFailure, configureAwait);

    public static Task Handle<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess, Action<TError> OnFailure, bool configureAwait = false)
        => taskResult.Match(OnSuccess, OnFailure, configureAwait);

    public static Task Handle<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
        => result.Match(OnSuccess, OnFailure, configureAwait);

    public static Task Handle<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure, bool configureAwait = false)
        => result.Match(OnSuccess, OnFailure, configureAwait);

    public static Task Handle<TError, TSuccess>(this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
        => result.Match(OnSuccess, OnFailure, configureAwait);
}
