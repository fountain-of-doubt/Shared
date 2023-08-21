namespace Shared.Functional;

public static partial class ResultTEExtensions
{
    public static Result<TError, TSuccess> Tap<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TSuccess> tap)
    {
        if (result.IsSuccess) { tap(result.SuccessContent); }
        return result;
    }
}
