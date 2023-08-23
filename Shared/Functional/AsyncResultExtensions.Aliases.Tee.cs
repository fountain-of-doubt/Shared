namespace Shared.Functional;

public static partial class ResultExtensions
{
    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnSuccess)
        => taskResult.TapFailure(OnSuccess);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnSuccess)
        => taskResult.TapFailure(OnSuccess);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnSuccess)
        => result.TapFailure(OnSuccess);



    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnFailure)
        => taskResult.TapFailure(OnFailure);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnFailure)
        => taskResult.TapFailure(OnFailure);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnFailure)
        => result.TapFailure(OnFailure);



    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnSuccess, Func<Task> OnFailure)
        => taskResult.Tap(OnSuccess, OnFailure);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnSuccess, Action OnFailure)
        => taskResult.Tap(OnSuccess, OnFailure);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnSuccess, Func<Task> OnFailure)
        => taskResult.Tap(OnSuccess, OnFailure);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnSuccess, Action OnFailure)
        => taskResult.Tap(OnSuccess, OnFailure);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnSuccess, Func<Task> OnFailure)
        => result.Tap(OnSuccess, OnFailure);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnSuccess, Action OnFailure)
        => result.Tap(OnSuccess, OnFailure);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Result<TError, TSuccess> result, Action OnSuccess, Func<Task> OnFailure)
        => result.Tap(OnSuccess, OnFailure);



    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Func<TSuccess, Task> OnSuccess)
        => result.Tap(OnSuccess);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Action<TSuccess> OnSuccess)
        => result.Tap(OnSuccess);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess)
        => result.Tap(OnSuccess);



    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Func<TError, Task> OnFailure)
        => result.TapFailure(OnFailure);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Action<TError> OnFailure)
        => result.TapFailure(OnFailure);

    public static Task<Result<TError, TSuccess>> Tee<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TError, Task> OnFailure)
        => result.TapFailure(OnFailure);



    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure)
        => result.Tap(OnSuccess, OnFailure);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure)
        => result.Tap(OnSuccess, OnFailure);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure)
        => result.Tap(OnSuccess, OnFailure);
    
    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> result, Action<TSuccess> OnSuccess, Action<TError> OnFailure)
        => result.Tap(OnSuccess, OnFailure);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure)
        => result.Tap(OnSuccess, OnFailure);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure)
        => result.Tap(OnSuccess, OnFailure);

    public static Task<Result<TError, TSuccess>> TeeFailure<TError, TSuccess>(this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure)
        => result.Tap(OnSuccess, OnFailure);
}
