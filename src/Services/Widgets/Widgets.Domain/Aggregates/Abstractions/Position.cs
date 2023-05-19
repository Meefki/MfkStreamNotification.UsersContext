using Subscriptions.Domain.SeedWork;

namespace Subscriptions.Domain.Aggregates.Abstractions;

public class Position
    : ValueObject
{
    public float PosX { get; init; }
    public float PosY { get; init; }

    public Position(
        float posX,
        float posY)
    {
        PosX = posX;
        PosY = posY;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PosX;
        yield return PosY;
    }

    public static bool operator ==(Position left, Position right)
        => EqualOperator(left, right);

    public static bool operator !=(Position left, Position right)
        => NotEqualOperator(left, right);

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}