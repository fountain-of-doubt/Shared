namespace Shared.Functional;

public static partial class OptionExtensionsAsync
{
    public static async Task<TOut> Match<T, TOut>(this Option<T> option, Func<T, TOut> WhenSome, Func<Task<TOut>> WhenNoneAsync, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        return option.IsNone
                ? await WhenNoneAsync().ConfigureAwait(asyncConfig.configureAwaitOnNone)
                : WhenSome(option.Value);
    }

    public static async Task<TOut> Match<T, TOut>(this Option<T> option, Func<T, Task<TOut>> WhenSomeAsync, Func<TOut> WhenNone, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        return option.IsNone
                ? WhenNone()
                : await WhenSomeAsync(option.Value).ConfigureAwait(asyncConfig.configureAwaitOnSome);
    }

    public static async Task<TOut> Match<T, TOut>(this Option<T> option, Func<T, Task<TOut>> WhenSomeAsync, Func<Task<TOut>> WhenNoneAsync, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        return option.IsNone
                ? await WhenNoneAsync().ConfigureAwait(asyncConfig.configureAwaitOnNone)
                : await WhenSomeAsync(option.Value).ConfigureAwait(asyncConfig.configureAwaitOnSome);
    }

    public static async Task<TOut> Match<T, TOut>(this Task<Option<T>> optionTask, Func<T, TOut> WhenSome, Func<TOut> WhenNone, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        return result.IsNone
            ? WhenNone()
            : WhenSome(result.Value);
    }

    public static async Task<TOut> Match<T, TOut>(this Task<Option<T>> optionTask, Func<T, TOut> WhenSome, Func<Task<TOut>> WhenNoneAsync, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        return result.IsNone
            ? await WhenNoneAsync().ConfigureAwait(asyncConfig.configureAwaitOnNone)
            : WhenSome(result.Value);
    }

    public static async Task<TOut> Match<T, TOut>(this Task<Option<T>> optionTask, Func<T, Task<TOut>> WhenSomeAsync, Func<TOut> WhenNone, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        return result.IsNone
            ? WhenNone()
            : await WhenSomeAsync(result.Value).ConfigureAwait(asyncConfig.configureAwaitOnSome);
    }

    public static async Task<TOut> Match<T, TOut>(this Task<Option<T>> optionTask, Func<T, Task<TOut>> WhenSomeAsync, Func<Task<TOut>> WhenNoneAsync, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        return result.IsNone
            ? await WhenNoneAsync().ConfigureAwait(asyncConfig.configureAwaitOnNone)
            : await WhenSomeAsync(result.Value).ConfigureAwait(asyncConfig.configureAwaitOnSome);
    }


    public static async Task Match<T>(this Option<T> option, Action<T> WhenSome, Func<Task> WhenNoneAync, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        if (option.IsNone) { await WhenNoneAync().ConfigureAwait(asyncConfig.configureAwaitOnNone); }
        else { WhenSome(option.Value); };
    }

    public static async Task Match<T>(this Option<T> option, Func<T, Task> WhenSomeAsync, Action WhenNone, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        if (option.IsNone) { WhenNone(); }
        else { await WhenSomeAsync(option.Value).ConfigureAwait(asyncConfig.configureAwaitOnSome); };
    }

    public static async Task Match<T>(this Option<T> option, Func<T, Task> WhenSomeAsync, Func<Task> WhenNoneAsync, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        if (option.IsNone) { await WhenNoneAsync().ConfigureAwait(asyncConfig.configureAwaitOnNone); }
        else { await WhenSomeAsync(option.Value).ConfigureAwait(asyncConfig.configureAwaitOnSome); };
    }


    public static async Task Match<T>(this Task<Option<T>> optionTask, Action<T> WhenSome, Action WhenNone, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        if (result.IsNone) { WhenNone(); }
        else { WhenSome(result.Value); };
    }

    public static async Task Match<T>(this Task<Option<T>> optionTask, Action<T> WhenSome, Func<Task> WhenNoneAsync, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        if (result.IsNone) { await WhenNoneAsync().ConfigureAwait(asyncConfig.configureAwaitOnNone); }
        else { WhenSome(result.Value); };
    }

    public static async Task Match<T>(this Task<Option<T>> optionTask, Func<T, Task> WhenSomeAsync, Action WhenNone, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        if (result.IsNone) { WhenNone(); }
        else { await WhenSomeAsync(result.Value).ConfigureAwait(asyncConfig.configureAwaitOnSome); };
    }

    public static async Task Match<T>(this Task<Option<T>> optionTask, Func<T, Task> WhenSomeAsync, Func<Task> WhenNoneAsync, OptionAsyncConfig.Match? asyncConfig = null)
    {
        asyncConfig ??= OptionAsyncConfig.Match.Default;
        var result = await optionTask.ConfigureAwait(asyncConfig.configureAwaitOption);
        if (result.IsNone) { await WhenNoneAsync().ConfigureAwait(asyncConfig.configureAwaitOnNone); }
        else { await WhenSomeAsync(result.Value).ConfigureAwait(asyncConfig.configureAwaitOnSome); };
    }
}
