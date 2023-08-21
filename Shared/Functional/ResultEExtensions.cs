namespace Shared.Functional;

public static class ResultEExtensions
{
    public static TOut Match<TError, TOut>(in this Result<TError> result, Func<TOut> OnSuccess, Func<TError, TOut> OnFail)
        => result.IsSuccess
            ? OnSuccess()
            : OnFail(result.ErrorContent);

    public static void Match<TError>(in this Result<TError> result, Action OnSuccess, Action<TError> OnFail)
    {
        if (result.IsSuccess) { OnSuccess(); }
        else { OnFail(result.ErrorContent); }
    }
}
