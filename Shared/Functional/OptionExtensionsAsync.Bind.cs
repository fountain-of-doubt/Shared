namespace Shared.Functional;

public static partial class OptionExtensionsAsync
{

    public static async Task<Option<TOut>> Bind<T, TOut>(this Option<T> option, Func<T, Task<Option<TOut>>> bindAsync) 
        => option.IsNone
            ? Option<TOut>.None
            : await bindAsync(option.Value).ConfigureAwait(false);

    public static async Task<Option<TOut>> Bind<T, TOut>(this Task<Option<T>> optionTask, Func<T, Option<TOut>> bind)
    {
        var result = await optionTask.ConfigureAwait(false);
        return result.IsNone
            ? Option<TOut>.None
            : bind(result.Value);
    }

    public static async Task<Option<TOut>> Bind<T, TOut>(this Task<Option<T>> optionTask, Func<T, Task<Option<TOut>>> bindAsync)
    {
        var result = await optionTask.ConfigureAwait(false);
        return result.IsNone
            ? Option<TOut>.None
            : await bindAsync(result.Value).ConfigureAwait(false);
    }
}
