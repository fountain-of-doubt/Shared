using Shared.Functional.Optional;

namespace Shared.Functional;

public static partial class OptionExtensionsAsync
{
    public static async Task<Option<TOut>> Bind<T, TOut>(this Option<T> option, Func<T, Task<Option<TOut>>> bindAsync, OptionAsyncConfig.Bind? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Bind.Default;
        return option.IsNone
            ? Option<TOut>.None
            : await bindAsync(option.Value).ConfigureAwait(asyncConfig.configureAwaitBind);
    }

    public static async Task<Option<TOut>> Bind<T, TOut>(this Task<Option<T>> optionTask, Func<T, Option<TOut>> bind, OptionAsyncConfig.Bind? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Bind.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        return result.IsNone
            ? Option<TOut>.None
            : bind(result.Value);
    }

    public static async Task<Option<TOut>> Bind<T, TOut>(this Task<Option<T>> optionTask, Func<T, Task<Option<TOut>>> bindAsync, OptionAsyncConfig.Bind? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Bind.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        return result.IsNone
            ? Option<TOut>.None
            : await bindAsync(result.Value).ConfigureAwait(asyncConfig.configureAwaitBind);
    }
}
