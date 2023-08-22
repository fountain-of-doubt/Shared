namespace Shared.Functional;

public static partial class ResultTEExtensions
{
    public static TOut Match<TError, TSuccess, TOut>(in this Result<TError, TSuccess> result, Func<TSuccess, TOut> OnSuccess, Func<TError, TOut> OnFailure)
        => result.IsSuccess
            ? OnSuccess(result.SuccessContent)
            : OnFailure(result.ErrorContent);

    public static void Match<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Action<TError> OnFailure)
    {
        if (result.IsSuccess) { OnSuccess(result.SuccessContent); }
        else { OnFailure(result.ErrorContent); }
    }
}
