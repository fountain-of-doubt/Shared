namespace Shared.Functional;

public static partial class ResultExtensions
{
    public static Result<TError, TSuccess> TapSuccess<TError, TSuccess>(in this Result<TError, TSuccess> result, Action OnSuccess)
    {
        if (result.IsSuccess) { OnSuccess(); }
        return result;
    }

    public static Result<TError, TSuccess> TapError<TError, TSuccess>(in this Result<TError, TSuccess> result, Action OnFail)
    {
        if (result.IsFail) { OnFail(); }
        return result;
    }

    public static Result<TError, TSuccess> Tap<TError, TSuccess>(in this Result<TError, TSuccess> result, Action OnSuccess, Action OnFail)
    {
        if (result.IsSuccess) { OnSuccess(); }
        else { OnFail(); }
        return result;
    }

    public static Result<TError, TSuccess> Tap<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess)
    {
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        return result;
    }

    public static Result<TError, TSuccess> Tap<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TError> OnFail)
    {
        if (result.IsFail) { OnFail(result.ErrorContent); }
        return result;
    }

    public static Result<TError, TSuccess> Tap<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Action<TError> OnFail)
    {
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { OnFail(result.ErrorContent); }
        return result;
    }
}
