﻿using Shared.Functional.Optional;

namespace Shared.Functional;

public static partial class OptionExtensionsAsync
{
    public static async Task<Option<TOut>> Bind<T, TOut>(this Option<T> option, Func<T, CancellationToken, Task<Option<TOut>>> bindAsync, OptionAsyncConfig.Bind? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Bind.Default;
        return option.IsNone
            ? Option<TOut>.None
            : await bindAsync(option.Value, asyncConfig.cancellationToken).ConfigureAwait(asyncConfig.configureAwaitBind);
    }

    public static async Task<Option<TOut>> Bind<T, TOut>(this Task<Option<T>> optionTask, Func<T, CancellationToken, Task<Option<TOut>>> bindAsync, OptionAsyncConfig.Bind? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Bind.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        return result.IsNone
            ? Option<TOut>.None
            : await bindAsync(result.Value, asyncConfig.cancellationToken).ConfigureAwait(asyncConfig.configureAwaitBind);
    }
}
