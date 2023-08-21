﻿namespace Shared.Functional;

public static partial class ResultTEExtensions
{
    public static Result<TError, TOut> Map<TError, TSuccess, TOut>(in this Result<TError, TSuccess> result, Func<TSuccess, TOut> map)
        => result.IsSuccess
            ? Result<TError, TOut>.Success(map(result.SuccessContent))
            : Result<TError, TOut>.Fail(result.ErrorContent);
}
