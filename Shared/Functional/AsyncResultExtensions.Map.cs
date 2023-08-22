namespace Shared.Functional;

public static partial class AsyncResultExtensions
{
    public static async Task<Result<TError, TOut>> Map<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> resultTask, 
        Func<TSuccess, Task<TOut>> map,
        bool configureAwait = false)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);

        return result.IsSuccess
            ? await map(result.SuccessContent).ConfigureAwait(configureAwait)
            : result.FailureContent;
    }

    public static async Task<Result<TError, TOut>> Map<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> resultTask, 
        Func<TSuccess, TOut> map,
        bool configureAwait = false)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);

        return result.IsSuccess
            ? map(result.SuccessContent)
            : result.FailureContent;
    }

    public static async Task<Result<TError, TOut>> Map<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, 
        Func<TSuccess, Task<TOut>> map,
        bool configureAwait = false)
    {
        return result.IsSuccess
            ? await map(result.SuccessContent).ConfigureAwait(configureAwait)
            : result.FailureContent;
    }
}
