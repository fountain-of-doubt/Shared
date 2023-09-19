using Shared.Functional.Results;

namespace Shared.Functional;

public static partial class ResultExtensions
{
    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, Task<TOut>> OnFailure)
        => taskResult.Match(OnSuccess, OnFailure);

    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, TOut> OnFailure)
        => taskResult.Match(OnSuccess, OnFailure);

    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, TOut> OnSuccess, Func<TError, Task<TOut>> OnFailure)
        => taskResult.Match(OnSuccess, OnFailure);

    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, TOut> OnSuccess, Func<TError, TOut> OnFailure)
        => taskResult.Match(OnSuccess, OnFailure);

    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, Task<TOut>> OnFailure)
        => result.Match(OnSuccess, OnFailure);

    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, TOut> OnFailure)
        => result.Match(OnSuccess, OnFailure);

    public static Task<TOut> Handle<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, TOut> OnSuccess, Func<TError, Task<TOut>> OnFailure)
        => result.Match(OnSuccess, OnFailure);



    public static Task Handle<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure)
        => taskResult.Match(OnSuccess, OnFailure);

    public static Task Handle<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure)
        => taskResult.Match(OnSuccess, OnFailure);

    public static Task Handle<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure)
        => taskResult.Match(OnSuccess, OnFailure);

    public static Task Handle<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess, Action<TError> OnFailure)
        => taskResult.Match(OnSuccess, OnFailure);

    public static Task Handle<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure)
        => result.Match(OnSuccess, OnFailure);

    public static Task Handle<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure)
        => result.Match(OnSuccess, OnFailure);

    public static Task Handle<TError, TSuccess>(this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure)
        => result.Match(OnSuccess, OnFailure);
}
