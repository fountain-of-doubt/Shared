namespace Shared.Functional;

public static partial class OptionExtensionsAsync
{
    public static async Task<TOut> Match<T, TOut>(this Option<T> option, Func<T, TOut> WhenSome, Func<Task<TOut>> WhenNoneAsync)
        => option.IsNone
            ? await WhenNoneAsync().ConfigureAwait(false)
            : WhenSome(option.Value);

    public static async Task<TOut> Match<T, TOut>(this Option<T> option, Func<T, Task<TOut>> WhenSomeAsync, Func<TOut> WhenNone)
        => option.IsNone
            ? WhenNone()
            : await WhenSomeAsync(option.Value).ConfigureAwait(false);

    public static async Task<TOut> Match<T, TOut>(this Option<T> option, Func<T, Task<TOut>> WhenSomeAsync, Func<Task<TOut>> WhenNoneAsync)
        => option.IsNone
            ? await WhenNoneAsync().ConfigureAwait(false)
            : await WhenSomeAsync(option.Value).ConfigureAwait(false);

    public static async Task<TOut> Match<T, TOut>(this Task<Option<T>> optionTask, Func<T, TOut> WhenSome, Func<TOut> WhenNone)
    {
        var result = await optionTask.ConfigureAwait(false);
        return result.IsNone
            ? WhenNone()
            : WhenSome(result.Value);
    }

    public static async Task<TOut> Match<T, TOut>(this Task<Option<T>> optionTask, Func<T, TOut> WhenSome, Func<Task<TOut>> WhenNoneAsync)
    {
        var result = await optionTask.ConfigureAwait(false);
        return result.IsNone
            ? await WhenNoneAsync().ConfigureAwait(false)
            : WhenSome(result.Value);
    }

    public static async Task<TOut> Match<T, TOut>(this Task<Option<T>> optionTask, Func<T, Task<TOut>> WhenSomeAsync, Func<TOut> WhenNone)
    {
        var result = await optionTask.ConfigureAwait(false);
        return result.IsNone
            ? WhenNone()
            : await WhenSomeAsync(result.Value).ConfigureAwait(false);
    }

    public static async Task<TOut> Match<T, TOut>(this Task<Option<T>> optionTask, Func<T, Task<TOut>> WhenSomeAsync, Func<Task<TOut>> WhenNoneAsync)
    {
        var result = await optionTask.ConfigureAwait(false);
        return result.IsNone
            ? await WhenNoneAsync().ConfigureAwait(false)
            : await WhenSomeAsync(result.Value).ConfigureAwait(false);
    }


    public static async Task Match<T>(this Option<T> option, Action<T> WhenSome, Func<Task> WhenNoneAync)
    {
        if (option.IsNone) { await WhenNoneAync().ConfigureAwait(false); }
        else { WhenSome(option.Value); };
    }

    public static async Task Match<T>(this Option<T> option, Func<T, Task> WhenSomeAsync, Action WhenNone)
    {
        if (option.IsNone) { WhenNone(); }
        else { await WhenSomeAsync(option.Value).ConfigureAwait(false); };
    }

    public static async Task Match<T>(this Option<T> option, Func<T, Task> WhenSomeAsync, Func<Task> WhenNoneAsync)
    {
        if (option.IsNone) { await WhenNoneAsync().ConfigureAwait(false); }
        else { await WhenSomeAsync(option.Value).ConfigureAwait(false); };
    }


    public static async Task Match<T>(this Task<Option<T>> optionTask, Action<T> WhenSome, Action WhenNone)
    {
        var result = await optionTask.ConfigureAwait(false);
        if (result.IsNone) { WhenNone(); }
        else { WhenSome(result.Value); };
    }

    public static async Task Match<T>(this Task<Option<T>> optionTask, Action<T> WhenSome, Func<Task> WhenNoneAsync)
    {
        var result = await optionTask.ConfigureAwait(false);
        if (result.IsNone) { await WhenNoneAsync().ConfigureAwait(false); }
        else { WhenSome(result.Value); };
    }

    public static async Task Match<T>(this Task<Option<T>> optionTask, Func<T, Task> WhenSomeAsync, Action WhenNone)
    {
        var result = await optionTask.ConfigureAwait(false);
        if (result.IsNone) { WhenNone(); }
        else { await WhenSomeAsync(result.Value).ConfigureAwait(false); };
    }

    public static async Task Match<T>(this Task<Option<T>> optionTask, Func<T, Task> WhenSomeAsync, Func<Task> WhenNoneAsync)
    {
        var result = await optionTask.ConfigureAwait(false);
        if (result.IsNone) { await WhenNoneAsync().ConfigureAwait(false); }
        else { await WhenSomeAsync(result.Value).ConfigureAwait(false); };
    }
}
