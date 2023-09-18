namespace Functional.UnitTests;

internal record class Alpha
{
    public Alpha(string content) => Content = content ?? throw new ArgumentNullException(nameof(content));
    public string Content { get; }
}

internal record class Beta
{
    public Beta(int value) => Value = value;
    public int Value { get; }
}

internal record class ValueObject (string name, int value);

internal static class Map
{
    internal static Func<Alpha, Alpha> Identity => (Alpha a) => a;
    internal static Func<Alpha, Alpha?> NullA => (Alpha a) => null;
    internal static Func<Alpha, Alpha> ReverseContent => (Alpha a) => new Alpha(new string(a.Content.Reverse().ToArray()));
    internal static Func<Alpha, Beta?> NullB => (Alpha a) => null;
    internal static Func<Alpha, Beta?> ParseContent => (Alpha a) => int.TryParse(a.Content, out var value) ? new Beta(value) : null;
}

internal static class Bind
{
    internal static Func<Alpha, Option<Alpha>> Identity => (Alpha a) => Option.From(a);
    internal static Func<Alpha, Option<Alpha>> NullA => (Alpha a) => null;
    internal static Func<Alpha, Option<Alpha>> ReverseContent => (Alpha a) => Option<Alpha>.From(new Alpha(new string(a.Content.Reverse().ToArray())));
    internal static Func<Alpha, Option<Beta>> ParseContent => (Alpha a) => Option<Beta>.From(int.TryParse(a.Content, out var value) ? new Beta(value) : null);
}
