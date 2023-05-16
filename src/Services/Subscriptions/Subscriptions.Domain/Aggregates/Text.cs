using Subscriptions.Domain.Aggregates.Abstractions;
using System;

namespace Subscriptions.Domain.Aggregates;

public class Text
    : ComponentVO
{
    public string Value { get; init; }
    public Font Font { get; init; }

    public Text(
        Position position, 
        Size size,
        Duration duration,
        string value,
        Font font) 
        : base(position, size, duration)
    {
        Value = value;
        Font = font;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return base.GetEqualityComponents();

        yield return Value;
        yield return Font;
    }

    public static bool operator ==(Text left, Text right)
        => EqualOperator(left, right);

    public static bool operator !=(Text left, Text right)
        => NotEqualOperator(left, right);

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public Text ChangeDuration(Duration duration)
        => new(Position, Size, duration, Value, Font);
}