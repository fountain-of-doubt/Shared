using Shared.Functional.Results;

namespace Shared.Functional;

public static partial class ResultExtensions
{
    public static Result<TError, TOut> OnSuccess<TError, TSuccess, TOut>(in this Result<TError, TSuccess> result, Func<TSuccess, Result<TError, TOut>> bind)
        => result.Bind(bind);

    public static Result<TError, TOut> OnSuccess<TError, TSuccess, TOut>(in this Result<TError, TSuccess> result, Func<TSuccess, TOut> map)
        => result.Map(map);


    public static Result<TError, TSuccess> Tee<TError, TSuccess>(in this Result<TError, TSuccess> result, Action OnSuccess)
        => result.TapFailure(OnSuccess);
    public static Result<TError, TSuccess> TeeFailure<TError, TSuccess>(in this Result<TError, TSuccess> result, Action OnFailure)
        => result.TapFailure(OnFailure);

    public static Result<TError, TSuccess> Tee<TError, TSuccess>(in this Result<TError, TSuccess> result, Action OnSuccess, Action OnFailure)
        => result.Tap(OnSuccess, OnFailure);

    public static Result<TError, TSuccess> Tee<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess)
        => result.Tap(OnSuccess);

    public static Result<TError, TSuccess> Tee<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TError> OnFailure)
        => result.TapFailure(OnFailure);

    public static Result<TError, TSuccess> TeeFailure<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Action<TError> OnFailure)
        => result.Tap(OnSuccess, OnFailure);


    public static TOut Handle<TError, TSuccess, TOut>(in this Result<TError, TSuccess> result, Func<TSuccess, TOut> OnSuccess, Func<TError, TOut> OnFailure)
        => result.Match(OnSuccess, OnFailure);

    public static void Handle<TError, TSuccess>(in this Result<TError, TSuccess> result, Action<TSuccess> OnSuccess, Action<TError> OnFailure)
        => result.Match(OnSuccess, OnFailure); 
}
