using Shared.Functional.Results;

namespace Shared.Functional;

public static partial class AsyncResultExtensions
{
    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnSuccess, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { await OnSuccess().ConfigureAwait(configureAwait); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnSuccess, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { OnSuccess(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnSuccess, bool configureAwait = false)
    {
        if (result.IsSuccess) { await OnSuccess().ConfigureAwait(configureAwait); }
        return result;
    }



    public static async Task<Result<TError, TSuccess>> TapFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsFail) { await OnFailure().ConfigureAwait(configureAwait); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> TapFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsFail) { OnFailure(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> TapFailure<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnFailure, bool configureAwait = false)
    {
        if (result.IsFail) { await OnFailure().ConfigureAwait(configureAwait); }
        return result;
    }



    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnSuccess, Action OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { OnSuccess(); }
        else { OnFailure(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnSuccess, Func<Task> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { await OnSuccess().ConfigureAwait(configureAwait); }
        else { await OnFailure().ConfigureAwait(configureAwait); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnSuccess, Action OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { await OnSuccess().ConfigureAwait(configureAwait); }
        else { OnFailure(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnSuccess, Func<Task> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { OnSuccess(); }
        else { await OnFailure().ConfigureAwait(configureAwait); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnSuccess, Func<Task> OnFailure, bool configureAwait = false)
    {
        if (result.IsSuccess) { await OnSuccess().ConfigureAwait(configureAwait); }
        else { await OnFailure().ConfigureAwait(configureAwait); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnSuccess, Action OnFailure, bool configureAwait = false)
    {
        if (result.IsSuccess) { await OnSuccess().ConfigureAwait(configureAwait); }
        else { OnFailure(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Action OnSuccess, Func<Task> OnFailure, bool configureAwait = false)
    {
        if (result.IsSuccess) { OnSuccess(); }
        else { await OnFailure().ConfigureAwait(configureAwait); }
        return result;
    }



    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, bool configureAwait = false)
    {
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait); }
        return result;
    }



    public static async Task<Result<TError, TSuccess>> TapFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TError, Task> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsFail) { await OnFailure(result.FailureContent).ConfigureAwait(configureAwait); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> TapFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TError> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsFail) { OnFailure(result.FailureContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> TapFailure<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TError, Task> OnFailure, bool configureAwait = false)
    {
        if (result.IsFail) { await OnFailure(result.FailureContent).ConfigureAwait(configureAwait); }
        return result;
    }



    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait); }
        else { await OnFailure(result.FailureContent).ConfigureAwait(configureAwait); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait); }
        else { OnFailure(result.FailureContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { await OnFailure(result.FailureContent).ConfigureAwait(configureAwait); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess, Action<TError> OnFailure, bool configureAwait = false)
    {
        var result = await taskResult.ConfigureAwait(configureAwait);
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { OnFailure(result.FailureContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
    {
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait); }
        else { await OnFailure(result.FailureContent).ConfigureAwait(configureAwait); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure, bool configureAwait = false)
    {
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent).ConfigureAwait(configureAwait); }
        else { OnFailure(result.FailureContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure, bool configureAwait = false)
    {
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { await OnFailure(result.FailureContent).ConfigureAwait(configureAwait); }
        return result;
    }
}
