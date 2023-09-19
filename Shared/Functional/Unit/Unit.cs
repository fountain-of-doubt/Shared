using System.Diagnostics.CodeAnalysis;

namespace Shared.Functional;

public readonly struct Unit : IEquatable<Unit>
{
    public static readonly Unit Value = default;

    public override int GetHashCode() => 0;

    public override bool Equals([NotNullWhen(true)] object? other) => other is Unit;
    public bool Equals(Unit other) => true;

    public static bool operator ==(Unit left, Unit right) => true;
    public static bool operator !=(Unit left, Unit right) => false;
}
