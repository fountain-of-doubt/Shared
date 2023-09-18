namespace Shared.Functional;

public static partial class OptionExtensionsAsync
{
    public static async Task<T?> Reduce<T>(this Task<Option<T>> optionTask, T? defaultValue)
    {
        var result = await optionTask.ConfigureAwait(false);
        return result.IsNone
            ? defaultValue
            : result.Value;
    }


    public static async Task<T?> Reduce<T>(this Option<T> option, Func<Task<T>> defaultValueAsync)
        => option.IsNone
            ? await defaultValueAsync().ConfigureAwait(false)
            : option.Value;

    public static async Task<T?> Reduce<T>(this Task<Option<T>> optionTask, Func<T> defaultValue)
    {
        var result = await optionTask.ConfigureAwait(false);
        return result.IsNone
            ? defaultValue()
            : result.Value;
    }

    public static async Task<T?> Reduce<T>(this Task<Option<T>> optionTask, Func<Task<T>> defaultValueAsync)
    {
        var result = await optionTask.ConfigureAwait(false);
        return result.IsNone
            ? await defaultValueAsync().ConfigureAwait(false)
            : result.Value;
    }
}
