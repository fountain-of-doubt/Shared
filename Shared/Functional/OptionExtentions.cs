namespace Shared.Functional;

public static class OptionExtentions
{
    public static Option<TOut> Map<T, TOut>(this Option<T> option, Func<T, TOut> map)
        => option.IsNone
            ? Option<TOut>.None
            : Option<TOut>.Some(map(option.Value));

    public static Option<TOut> Bind<T, TOut>(this Option<T> option, Func<T, Option<TOut>> bind)
        => option.IsNone
            ? Option<TOut>.None
            : bind(option.Value);

    public static T? Reduce<T>(this Option<T> option, T? defaultValue)
        => option.IsNone
            ? defaultValue
            : option.Value;

    public static T? Reduce<T>(this Option<T> option, Func<T> defaultValue)
        => option.IsNone
            ? defaultValue()
            : option.Value;


    public static TOut Match<T, TOut>(this Option<T> option, Func<T, TOut> WhenSome, Func<TOut> WhenNone)
        => option.IsNone
            ? WhenNone()
            : WhenSome(option.Value);

    public static void Match<T>(this Option<T> option, Action<T> WhenSome, Action WhenNone)
    {
        if (option.IsNone) { WhenNone(); }
        else { WhenSome(option.Value); };
    }
}
