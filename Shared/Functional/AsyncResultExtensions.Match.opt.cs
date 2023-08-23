namespace Shared.Functional;

public static partial class AsyncResultExtensions
{
    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, Task<TOut>> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        return result.IsSuccess
            ? await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait)
            : await OnFailure(result.FailureContent).ConfigureAwait(configureAwait);
    }

    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, TOut> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        return result.IsSuccess
            ? await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait)
            : OnFailure(result.FailureContent);
    }

    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, TOut> OnSuccess, Func<TError, Task<TOut>> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        return result.IsSuccess
            ? OnSuccess(result.SuccessContent)
            : await OnFailure(result.FailureContent).ConfigureAwait(configureAwait);
    }

    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, TOut> OnSuccess, Func<TError, TOut> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        return result.IsSuccess
            ? OnSuccess(result.SuccessContent)
            : OnFailure(result.FailureContent);
    }

    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, Task<TOut>> OnFailure, bool configureAwait = false)
    {
        return result.IsSuccess
            ? await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait)
            : await OnFailure(result.FailureContent).ConfigureAwait(configureAwait);
    }

    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, Task<TOut>> OnSuccess, Func<TError, TOut> OnFailure, bool configureAwait = false)
    {
        return result.IsSuccess
            ? await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait)
            : OnFailure(result.FailureContent);
    }

    public static async Task<TOut> Match<TError, TSuccess, TOut>(this Result<TError, TSuccess> result, Func<TSuccess, TOut> OnSuccess, Func<TError, Task<TOut>> OnFailure, bool configureAwait = false)
    {
        return result.IsSuccess
            ? OnSuccess(result.SuccessContent)
            : await OnFailure(result.FailureContent).ConfigureAwait(configureAwait);
    }


    public static async Task Match<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait); }
        else { await OnFailure(result.FailureContent).ConfigureAwait(configureAwait); }
    }

    public static async Task Match<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait); }
        else { OnFailure(result.FailureContent); }
    }

    public static async Task Match<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { await OnFailure(result.FailureContent).ConfigureAwait(configureAwait); }
    }

    public static async Task Match<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess, Action<TError> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { OnFailure(result.FailureContent); }
    }

    public static async Task Match<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
    {
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait); }
        else { await OnFailure(result.FailureContent).ConfigureAwait(configureAwait); }
    }

    public static async Task Match<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure, bool configureAwait = false)
    {
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait); }
        else { OnFailure(result.FailureContent); }
    }

    public static async Task Match<TError, TSuccess>(this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
    {
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { await OnFailure(result.FailureContent).ConfigureAwait(configureAwait); }
    }
}
