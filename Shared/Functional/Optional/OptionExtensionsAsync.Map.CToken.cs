﻿using Shared.Functional.Optional;

namespace Shared.Functional;

public static partial class OptionExtensionAsync
{
    public static async Task<Option<TOut>> Map<T, TOut>(this Option<T> option, Func<T, CancellationToken, Task<TOut?>> mapAsync, OptionAsyncConfig.Map? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Map.Default;
        return option.IsNone
            ? Option<TOut>.None
            : Option<TOut>.From(await mapAsync(option.Value, asyncConfig.cancellationToken).ConfigureAwait(asyncConfig.configureAwaitOption));
    }

    public static async Task<Option<TOut>> Map<T, TOut>(this Task<Option<T>> optionTask, Func<T, CancellationToken, Task<TOut?>> mapAsync, OptionAsyncConfig.Map? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Map.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        return result.IsNone
            ? Option<TOut>.None
            : Option<TOut>.From(await mapAsync(result.Value, asyncConfig.cancellationToken).ConfigureAwait(asyncConfig.configureAwaitMap));
    }
}
