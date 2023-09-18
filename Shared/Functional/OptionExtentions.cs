namespace Shared.Functional;

public static class Option
{
    public static Option<T> Some<T>(T value) => Option<T>.Some(value);
    public static Option<T> From<T>(T? value) => Option<T>.From(value);
}


public static class OptionExtentions
{
    public static Option<TOut> Map<T, TOut>(in this Option<T> option, Func<T, TOut?> map)
        => option.IsNone
            ? Option<TOut>.None
            : Option<TOut>.From(map(option.Value));

    public static Option<TOut> Bind<T, TOut>(in this Option<T> option, Func<T, Option<TOut>> bind)
        => option.IsNone
            ? Option<TOut>.None
            : bind(option.Value);

    public static T? Reduce<T>(in this Option<T> option, T? defaultValue)
        => option.IsNone
            ? defaultValue
            : option.Value;

    public static T? Reduce<T>(in this Option<T> option, Func<T> defaultValue)
        => option.IsNone
            ? defaultValue()
            : option.Value;


    public static TOut Match<T, TOut>(in this Option<T> option, Func<T, TOut> WhenSome, Func<TOut> WhenNone)
        => option.IsNone
            ? WhenNone()
            : WhenSome(option.Value);

    public static void Match<T>(in this Option<T> option, Action<T> WhenSome, Action WhenNone)
    {
        if (option.IsNone) { WhenNone(); }
        else { WhenSome(option.Value); };
    }
}
