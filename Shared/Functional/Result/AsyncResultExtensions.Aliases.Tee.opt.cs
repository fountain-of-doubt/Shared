using Shared.Functional.Results;

namespace Shared.Functional;

public static partial class ResultExtensions
{
    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnSuccess, bool configureAwait = false)
        => taskResult.TapFailure(OnSuccess, configureAwait);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnSuccess, bool configureAwait = false)
        => taskResult.TapFailure(OnSuccess, configureAwait);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnSuccess, bool configureAwait = false)
        => result.TapFailure(OnSuccess, configureAwait);



    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnFailure, bool configureAwait = false)
        => taskResult.TapFailure(OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnFailure, bool configureAwait = false)
        => taskResult.TapFailure(OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnFailure, bool configureAwait = false)
        => result.TapFailure(OnFailure, configureAwait);



    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnSuccess, Func<Task> OnFailure, bool configureAwait = false)
        => taskResult.Tap(OnSuccess, OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnSuccess, Action OnFailure, bool configureAwait = false)
        => taskResult.Tap(OnSuccess, OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnSuccess, Func<Task> OnFailure, bool configureAwait = false)
        => taskResult.Tap(OnSuccess, OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnSuccess, Action OnFailure, bool configureAwait = false)
        => taskResult.Tap(OnSuccess, OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnSuccess, Func<Task> OnFailure, bool configureAwait = false)
        => result.Tap(OnSuccess, OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnSuccess, Action OnFailure, bool configureAwait = false)
        => result.Tap(OnSuccess, OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Result<TError, TSuccess> result, Action OnSuccess, Func<Task> OnFailure, bool configureAwait = false)
        => result.Tap(OnSuccess, OnFailure, configureAwait);



    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Func<TSuccess, Task> OnSuccess, bool configureAwait = false)
        => result.Tap(OnSuccess, configureAwait);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Action<TSuccess> OnSuccess, bool configureAwait = false)
        => result.Tap(OnSuccess, configureAwait);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, bool configureAwait = false)
        => result.Tap(OnSuccess, configureAwait);



    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Func<TError, Task> OnFailure, bool configureAwait = false)
        => result.TapFailure(OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Action<TError> OnFailure, bool configureAwait = false)
        => result.TapFailure(OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TError, Task> OnFailure, bool configureAwait = false)
        => result.TapFailure(OnFailure, configureAwait);



    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
        => result.Tap(OnSuccess, OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure, bool configureAwait = false)
        => result.Tap(OnSuccess, OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
        => result.Tap(OnSuccess, OnFailure, configureAwait);
    
    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Action<TSuccess> OnSuccess, Action<TError> OnFailure, bool configureAwait = false)
        => result.Tap(OnSuccess, OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
        => result.Tap(OnSuccess, OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure, bool configureAwait = false)
        => result.Tap(OnSuccess, OnFailure, configureAwait);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
        => result.Tap(OnSuccess, OnFailure, configureAwait);
}
