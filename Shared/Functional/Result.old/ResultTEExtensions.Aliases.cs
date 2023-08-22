namespace Shared.Functional;

public static partial class ResultTEExtensions
{
    public static Result<TError, TOut> OnSuccess<TError, TSuccess, TOut>(in this Result<TError, TSuccess> result, Func<TSuccess, Result<TError, TOut>> bind)
        => result.Bind(bind);

    public static Result<TError, TOut> OnSuccess<TError, TSuccess, TOut>(in this Result<TError, TSuccess> result, Func<TSuccess, TOut> map)
        => result.Map(map);


    public static TOut Handle<TError, TSuccess, TOut>(in this Result<TError, TSuccess> result, Func<TSuccess, TOut> OnSuccess, Func<TError, TOut> OnFailure)
        => result.Match(OnSuccess, OnFailure);

    public static void Handle<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Action<TError> OnFailure)
        => result.Match(OnSuccess, OnFailure); 
}
