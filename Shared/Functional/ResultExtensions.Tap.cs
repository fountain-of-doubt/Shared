namespace Shared.Functional;

public static partial class ResultExtensions
{
    public static Result<TError, TSuccess> Tap<TError, TSuccess>(in this Result<TError, TSuccess> result, Action OnSuccess)
    {
        if (result.IsSuccess) { OnSuccess(); }
        return result;
    }

    public static Result<TError, TSuccess> TapFailure<TError, TSuccess>(in this Result<TError, TSuccess> result, Action OnFailure)
    {
        if (result.IsFail) { OnFailure(); }
        return result;
    }

    public static Result<TError, TSuccess> Tap<TError, TSuccess>(in this Result<TError, TSuccess> result, Action OnSuccess, Action OnFailure)
    {
        if (result.IsSuccess) { OnSuccess(); }
        else { OnFailure(); }
        return result;
    }

    public static Result<TError, TSuccess> Tap<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess)
    {
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        return result;
    }

    public static Result<TError, TSuccess> TapFailure<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TError> OnFailure)
    {
        if (result.IsFail) { OnFailure(result.FailureContent); }
        return result;
    }

    public static Result<TError, TSuccess> Tap<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Action<TError> OnFailure)
    {
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { OnFailure(result.FailureContent); }
        return result;
    }
}
