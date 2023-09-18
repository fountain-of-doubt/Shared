using Shared.Functional.Results;

namespace Shared.Functional;

public static partial class AsyncResultExtensions
{
    public static async Task<TSuccess?> Reduce<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, TSuccess? defaultValue, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        return result.IsSuccess
            ? result.SuccessContent
            : defaultValue;
    }

    public static async Task<TSuccess?> Reduce<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task<TSuccess>> defaultValue, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        return result.IsSuccess
               ? result.SuccessContent
              : await defaultValue();
    }

    public static async Task<TSuccess?> Reduce<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess> defaultValue, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        return result.IsSuccess
             ? result.SuccessContent
            : defaultValue();
    }

    public static async Task<TSuccess?> Reduce<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task<TSuccess>> defaultValue, bool configureAwait = false)
    {
        return result.IsSuccess
             ? result.SuccessContent
            : await defaultValue().ConfigureAwait(configureAwait);
    }
}
