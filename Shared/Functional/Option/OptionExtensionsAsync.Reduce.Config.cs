using Shared.Functional.Optional;

namespace Shared.Functional;

public static partial class OptionExtensionsAsync
{
    public static async Task<T?> Reduce<T>(this Task<Option<T>> optionTask, T? defaultValue, OptionAsyncConfig.Reduce? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Reduce.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        return result.IsNone
            ? defaultValue
            : result.Value;
    }


    public static async Task<T?> Reduce<T>(this Option<T> option, Func<Task<T>> defaultValueAsync, OptionAsyncConfig.Reduce? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Reduce.Default;
        return option.IsNone
                ? await defaultValueAsync().ConfigureAwait(asyncConfig.configureAwaitDefault)
                : option.Value;
    }

    public static async Task<T?> Reduce<T>(this Task<Option<T>> optionTask, Func<T> defaultValue, OptionAsyncConfig.Reduce? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Reduce.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        return result.IsNone
            ? defaultValue()
            : result.Value;
    }

    public static async Task<T?> Reduce<T>(this Task<Option<T>> optionTask, Func<Task<T>> defaultValueAsync, OptionAsyncConfig.Reduce? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Reduce.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        return result.IsNone
            ? await defaultValueAsync().ConfigureAwait(asyncConfig.configureAwaitDefault)
            : result.Value;
    }
}
