using Shared.Functional.Results;

namespace Shared.Functional;

public static partial class AsyncResultExtensions
{
    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, Task<TOut>> OnFailure)
    {
        var result = await taskResult;
        return result.IsSuccess
            ? await OnSuccess(result.SuccessContent)
            : await OnFailure(result.FailureContent);
    }

    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, TOut> OnFailure)
    {
        var result = await taskResult;
        return result.IsSuccess
            ? await OnSuccess(result.SuccessContent)
            : OnFailure(result.FailureContent);
    }

    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, TOut> OnSuccess, Func<TError, Task<TOut>> OnFailure)
    {
        var result = await taskResult;
        return result.IsSuccess
            ? OnSuccess(result.SuccessContent)
            : await OnFailure(result.FailureContent);
    }

    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, TOut> OnSuccess, Func<TError, TOut> OnFailure)
    {
        var result = await taskResult;
        return result.IsSuccess
            ? OnSuccess(result.SuccessContent)
            : OnFailure(result.FailureContent);
    }

    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, Task<TOut>> OnFailure)
    {
        return result.IsSuccess
            ? await OnSuccess(result.SuccessContent)
            : await OnFailure(result.FailureContent);
    }

    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, TOut> OnFailure)
    {
        return result.IsSuccess
            ? await OnSuccess(result.SuccessContent)
            : OnFailure(result.FailureContent);
    }

    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, TOut> OnSuccess, Func<TError, Task<TOut>> OnFailure)
    {
        return result.IsSuccess
            ? OnSuccess(result.SuccessContent)
            : await OnFailure(result.FailureContent);
    }


    public static async Task Match<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure)
    {
        var result = await taskResult;
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent); }
        else { await OnFailure(result.FailureContent); }
    }

    public static async Task Match<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure)
    {
        var result = await taskResult;
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent); }
        else { OnFailure(result.FailureContent); }
    }

    public static async Task Match<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure)
    {
        var result = await taskResult;
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { await OnFailure(result.FailureContent); }
    }

    public static async Task Match<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess, Action<TError> OnFailure)
    {
        var result = await taskResult;
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { OnFailure(result.FailureContent); }
    }

    public static async Task Match<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure)
    {
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent); }
        else { await OnFailure(result.FailureContent); }
    }

    public static async Task Match<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure)
    {
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent); }
        else { OnFailure(result.FailureContent); }
    }

    public static async Task Match<TError, TSuccess>(this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure)
    {
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { await OnFailure(result.FailureContent); }
    }
}
