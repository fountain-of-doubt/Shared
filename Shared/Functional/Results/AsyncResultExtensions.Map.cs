using Shared.Functional.Results;

namespace Shared.Functional;

public static partial class AsyncResultExtensions
{
    public static async Task<Result<TError, TOut>> Map<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> resultTask,
        Func<TSuccess, Task<TOut>> map)
    {
        var result = await resultTask;

        return result.IsSuccess
            ? await map(result.SuccessContent)
            : result.FailureContent;
    }

    public static async Task<Result<TError, TOut>> Map<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> resultTask,
        Func<TSuccess, TOut> map)
    {
        var result = await resultTask;

        return result.IsSuccess
            ? map(result.SuccessContent)
            : result.FailureContent;
    }

    public static async Task<Result<TError, TOut>> Map<TError, TSuccess, TOut>(this Result<TError, TSuccess> result,
        Func<TSuccess, Task<TOut>> map)
    {
        return result.IsSuccess
            ? await map(result.SuccessContent)
            : result.FailureContent;
    }
}
