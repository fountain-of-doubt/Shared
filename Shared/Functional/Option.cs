using System.Diagnostics.CodeAnalysis;

namespace Shared.Functional;

public readonly struct Option<T> : IEquatable<Option<T>>
{
    private Option(T? value) => Value = value;

    public static implicit operator Option<T>(T? value) => value is null ? None : Some(value);

    public static readonly Option<T> None = new(default);
    public static Option<T> Some(T value) => new Option<T>(value ?? throw new ArgumentNullException(nameof(value)));
    public static Option<T> From(T? value) => value is null ? None : Some(value);

    internal T? Value { get; }

    [MemberNotNullWhen(false, nameof(Value))]
    internal bool IsNone => Value is null;
    [MemberNotNullWhen(true, nameof(Value))]
    internal bool IsSome => !IsNone;
    [MemberNotNullWhen(false, nameof(Value))]

    public override int GetHashCode() => IsSome ? Value.GetHashCode() : 0;

    public override bool Equals(object? other)
    {
        return other switch
        {
            null => false,
            Option<T> option => Equals(option),
            _ => false
        };
    }

    public bool Equals(Option<T> other) => Value is null ? other.Value is null : Value.Equals(other.Value);

    public static bool operator ==(Option<T>? left, Option<T>? right) => left is null ? right is null : left.Equals(right);
    public static bool operator !=(Option<T>? left, Option<T>? right) => !(left == right);
}
