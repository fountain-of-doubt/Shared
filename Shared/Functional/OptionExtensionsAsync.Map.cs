namespace Shared.Functional;

public static partial class OptionExtensionAsync
{
    public static async Task<Option<TOut>> Map<T, TOut>(this Option<T> option, Func<T, Task<TOut?>> mapAsync)
    {
        return option.IsNone
            ? Option<TOut>.None
            : Option<TOut>.From(await mapAsync(option.Value).ConfigureAwait(false));
    }

    public static async Task<Option<TOut>> Map<T, TOut>(this Task<Option<T>> optionTask, Func<T, TOut?> map)
    {
        var result = await optionTask.ConfigureAwait(false);
        return result.IsNone
            ? Option<TOut>.None
            : Option<TOut>.From(map(result.Value));
    }

    public static async Task<Option<TOut>> Map<T, TOut>(this Task<Option<T>> optionTask, Func<T, Task<TOut?>> mapAsync)
    {
        var result = await optionTask.ConfigureAwait(false);
        return result.IsNone
            ? Option<TOut>.None
            : Option<TOut>.From(await mapAsync(result.Value).ConfigureAwait(false));
    }
}
