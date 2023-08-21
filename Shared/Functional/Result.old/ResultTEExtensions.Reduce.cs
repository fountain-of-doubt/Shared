namespace Shared.Functional;

public static partial class ResultTEExtensions
{
    public static TSuccess? Reduce<TError, TSuccess>(in this Result<TError, TSuccess> result, TSuccess? defaultValue)
        => result.IsSuccess
            ? result.SuccessContent
            : defaultValue;

    public static TSuccess? Reduce<TError, TSuccess>(in this Result<TError, TSuccess> result, Func<TSuccess> defaultValue)
        => result.IsSuccess
            ? result.SuccessContent
            : defaultValue();
}
