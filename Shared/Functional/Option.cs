using System.Diagnostics.CodeAnalysis;

namespace Shared.Functional;

internal interface IOption
{
    public bool IsNone { get; }
}

public class Option<T> : IEquatable<Option<T>>, IOption
{
    private Option(T? value) => Value = value;

    public static implicit operator Option<T>(T? value) => value is null ? None : Some(value);

    public static Option<T> None => _none;
    public static Option<T> Some(T value) => new Option<T>(value ?? throw new ArgumentNullException(nameof(value)));
    public static Option<T> From(T? value) => value is null ? None : Some(value);

    internal T? Value { get; }

    [MemberNotNullWhen(false, nameof(Value))]
    internal bool IsNone => Value is null;
    [MemberNotNullWhen(true, nameof(Value))]
    internal bool IsSome => !IsNone;
    [MemberNotNullWhen(false, nameof(Value))]
    bool IOption.IsNone => IsNone;

    public override int GetHashCode() => IsSome ? Value.GetHashCode() : 0;

    public override bool Equals(object? other)
    {
        return other switch
        {
            null => false,
//            IOption option=> option.IsNone,
            Option<T> x => Equals(x),
            _ => false
        };
    }



    //public bool Equals(Option<T>? other)
    //{
    //    if (other is null) { return false; }
    //    if (Value is null) { return other.Value is null; }
    //    return Value.Equals(other.Value);
    //}

    //public bool Equals(Option<T> other) => Value is null ? other.Value is null : Value.Equals(other.Value);

    public bool Equals(Option<T>? other)
    {
        return other switch
        {
            null => false,
            not null when other.Value is null => Value is null,
            _ => other.Value.Equals(Value)
        };
    }

    public static bool operator ==(Option<T>? left, Option<T>? right) => left is null ? right is null : left.Equals(right);
    public static bool operator !=(Option<T>? left, Option<T>? right) => !(left == right);

    private static readonly Option<T> _none = new(default);
}
