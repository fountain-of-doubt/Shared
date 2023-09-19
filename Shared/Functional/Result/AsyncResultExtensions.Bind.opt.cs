using Shared.Functional.Results;

namespace Shared.Functional;

public static partial class ResultExtensions
{
    public static async Task<Result<TError, TOut>> Bind<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult,
        Func<TSuccess, Task<Result<TError, TOut>>> bind,
        bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        return result.IsSuccess
            ? await bind(result.SuccessContent).ConfigureAwait(configureAwait)
            : result.FailureContent;
    }

    public static async Task<Result<TError, TOut>> Bind<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult,
        Func<TSuccess, Result<TError, TOut>> bind,
        bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        return result.IsSuccess
            ? bind(result.SuccessContent)
            : result.FailureContent;
    }

    public static async Task<Result<TError, TOut>> Bind<TError, TSuccess, TOut>(this Result<TError, TSuccess> result,
        Func<TSuccess, Task<Result<TError, TOut>>> bind,
        bool configureAwait = false)
    {
        return result.IsSuccess
            ? await bind(result.SuccessContent).ConfigureAwait(configureAwait)
            : result.FailureContent;
    }
}