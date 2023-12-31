﻿using System.Diagnostics.CodeAnalysis;

namespace Shared.Functional;

public readonly struct None : IOption
{
    public static readonly None Value = new None();

    public override int GetHashCode() => 0;
    public override bool Equals([NotNullWhen(true)] object? other)
    {
        return other switch
        {
            null => false,
            None => true,
            IOption ioption => ioption.IsNone,
            _ => false
        };
    }

    public bool Equals<T>(Option<T> other) => other.IsNone;

    internal bool IsNone => true;
    internal bool IsSome => false;

    bool IOption.IsNone => true;
}