using Shared.Functional.Results;

namespace Shared.Functional;

public static partial class AsyncResultExtensions
{
    public static async Task<TSuccess?> Reduce<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, TSuccess? defaultValue)
    {
        var result = await taskResult;
        return result.IsSuccess
            ? result.SuccessContent
            : defaultValue;
    }

    public static async Task<TSuccess?> Reduce<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task<TSuccess>> defaultValue)
    {
        var result = await taskResult;
        return result.IsSuccess
               ? result.SuccessContent
              : await defaultValue();
    }

    public static async Task<TSuccess?> Reduce<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess> defaultValue)
    {
        var result = await taskResult;
        return result.IsSuccess
             ? result.SuccessContent
            : defaultValue();
    }

    public static async Task<TSuccess?> Reduce<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task<TSuccess>> defaultValue)
    {
        return result.IsSuccess
             ? result.SuccessContent
            : await defaultValue();
    }
}
