namespace Shared.Functional;

public static class ResultTEExtensions
{
    public static TOut Match<TError, TSuccess, TOut>(in this Result<TError, TSuccess> result, Func<TSuccess, TOut> OnSuccess, Func<TError, TOut> OnFail)
        => result.IsSuccess
            ? OnSuccess(result.SuccessContent)
            : OnFail(result.ErrorContent);

    public static void Match<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Action<TError> OnFail)
    {
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { OnFail(result.ErrorContent); }
    }
}
