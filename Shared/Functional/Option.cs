namespace Shared.Functional;

//TODO: move to OptionExtensions
public static class Option
{
    public static Option<T> Some<T>(T value) => Option<T>.Some(value);
    public static Option<T> From<T>(T? value) => Option<T>.From(value);
}
