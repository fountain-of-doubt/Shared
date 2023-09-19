using System.Diagnostics.CodeAnalysis;

namespace Shared.Functional;

public readonly struct Option<T> : IEquatable<Option<T>>, IOption
{
    private Option(bool isNone, T? value) => (IsNone, Value) = (isNone, value);

    public static readonly Option<T> None = new(true, default);
    public static Option<T> Some(T value) => new(false, value ?? throw new ArgumentNullException(nameof(value)));
    public static Option<T> From(T? value) => value is not null ? Some(value) : None;

    public static implicit operator Option<T>(T? value) => From(value);


    [MemberNotNullWhen(false, nameof(Value))]
    internal bool IsNone { get; }
    [MemberNotNullWhen(true, nameof(Value))]
    internal bool IsSome => !IsNone;
    internal T? Value { get; }

    bool IOption.IsNone => IsNone;


    // Equality implementation
    public override int GetHashCode() => IsSome ? Value.GetHashCode() : 0;

    public static bool operator ==(Option<T> left, Option<T> right) => left.Equals(right);
    public static bool operator !=(Option<T> left, Option<T> right) => !(left == right);

    public override bool Equals([NotNullWhen(true)] object? other)
    {
        return other switch
        {
            null => false,
            Option<T> option => Equals(option),
            IOption ioption => Equals(ioption),
            _ => false
        };
    }

    private bool Equals(IOption other)
    {
        return IsNone switch
        {
            true => other.IsNone,
            _ => false
        };
    }

    public bool Equals<R>(Option<R> other)
    {
        return IsNone switch
        {
            true => other.IsNone,
            _ => false
        };
    }

    public bool Equals(Option<T> other)
    {
        return IsNone switch
        {
            true => other.IsNone,
            false when other.IsSome => Value.Equals(other.Value),
            _ => false
        };
    }
}


