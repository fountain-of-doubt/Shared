using Shared.Functional.Results;

namespace Shared.Functional;

public static partial class ResultExtensions
{
    public static async Task<Result<TError, TOut>> Bind<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult,
        Func<TSuccess, Task<Result<TError, TOut>>> bind)
    {
        var result = await taskResult;
        return result.IsSuccess
            ? await bind(result.SuccessContent)
            : result.FailureContent;
    }

    public static async Task<Result<TError, TOut>> Bind<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult,
        Func<TSuccess, Result<TError, TOut>> bind)
    {
        var result = await taskResult;
        return result.IsSuccess
            ? bind(result.SuccessContent)
            : result.FailureContent;
    }

    public static async Task<Result<TError, TOut>> Bind<TError, TSuccess, TOut>(this Result<TError, TSuccess> result,
        Func<TSuccess, Task<Result<TError, TOut>>> bind)
    {
        return result.IsSuccess
            ? await bind(result.SuccessContent)
            : result.FailureContent;
    }
}