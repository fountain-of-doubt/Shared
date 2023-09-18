using Shared.Functional.Results;

namespace Shared.Functional;

public static partial class AsyncResultExtensions
{
    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnSuccess)
    {
        var result = await taskResult;
        if (result.IsSuccess) { await OnSuccess(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnSuccess)
    {
        var result = await taskResult;
        if (result.IsSuccess) { OnSuccess(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnSuccess)
    {
        if (result.IsSuccess) { await OnSuccess(); }
        return result;
    }



    public static async Task<Result<TError, TSuccess>> TapFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnFailure)
    {
        var result = await taskResult;
        if (result.IsFail) { await OnFailure(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> TapFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnFailure)
    {
        var result = await taskResult;
        if (result.IsFail) { OnFailure(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> TapFailure<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnFailure)
    {
        if (result.IsFail) { await OnFailure(); }
        return result;
    }



    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnSuccess, Action OnFailure)
    {
        var result = await taskResult;
        if (result.IsSuccess) { OnSuccess(); }
        else { OnFailure(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnSuccess, Func<Task> OnFailure)
    {
        var result = await taskResult;
        if (result.IsSuccess) { await OnSuccess(); }
        else { await OnFailure(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<Task> OnSuccess, Action OnFailure)
    {
        var result = await taskResult;
        if (result.IsSuccess) { await OnSuccess(); }
        else { OnFailure(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action OnSuccess, Func<Task> OnFailure)
    {
        var result = await taskResult;
        if (result.IsSuccess) { OnSuccess(); }
        else { await OnFailure(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnSuccess, Func<Task> OnFailure)
    {
        if (result.IsSuccess) { await OnSuccess(); }
        else { await OnFailure(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Func<Task> OnSuccess, Action OnFailure)
    {
        if (result.IsSuccess) { await OnSuccess(); }
        else { OnFailure(); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Action OnSuccess, Func<Task> OnFailure)
    {
        if (result.IsSuccess) { OnSuccess(); }
        else { await OnFailure(); }
        return result;
    }



    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess)
    {
        var result = await taskResult;
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess)
    {
        var result = await taskResult;
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess)
    {
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent); }
        return result;
    }



    public static async Task<Result<TError, TSuccess>> TapFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TError, Task> OnFailure)
    {
        var result = await taskResult;
        if (result.IsFail) { await OnFailure(result.FailureContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> TapFailure<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TError> OnFailure)
    {
        var result = await taskResult;
        if (result.IsFail) { OnFailure(result.FailureContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> TapFailure<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TError, Task> OnFailure)
    {
        if (result.IsFail) { await OnFailure(result.FailureContent); }
        return result;
    }



    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure)
    {
        var result = await taskResult;
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent); }
        else { await OnFailure(result.FailureContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure)
    {
        var result = await taskResult;
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent); }
        else { OnFailure(result.FailureContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure)
    {
        var result = await taskResult;
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { await OnFailure(result.FailureContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Task<Result<TError, TSuccess>> taskResult, Action<TSuccess> OnSuccess, Action<TError> OnFailure)
    {
        var result = await taskResult;
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { OnFailure(result.FailureContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Func<TError, Task> OnFailure)
    {
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent); }
        else { await OnFailure(result.FailureContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Func<TSuccess, Task> OnSuccess, Action<TError> OnFailure)
    {
        if (result.IsSuccess) { await OnSuccess(result.SuccessContent); }
        else { OnFailure(result.FailureContent); }
        return result;
    }

    public static async Task<Result<TError, TSuccess>> Tap<TError, TSuccess>(this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Func<TError, Task> OnFailure)
    {
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { await OnFailure(result.FailureContent); }
        return result;
    }
}
