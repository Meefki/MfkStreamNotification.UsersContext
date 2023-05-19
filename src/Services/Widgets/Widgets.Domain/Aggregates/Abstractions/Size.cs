using Subscriptions.Domain.DomainExceptions;
using Subscriptions.Domain.SeedWork;

namespace Subscriptions.Domain.Aggregates.Abstractions;

public class Size
    : ValueObject
{
    public float SizeX { get; init; }
    public float SizeY { get; init; }

    public Size(
        float sizeX,
        float sizeY)
    {
        if (sizeX < 0)
            throw new InvalidSizeException(nameof(SizeX), sizeX);
        if (sizeY < 0)
            throw new InvalidSizeException(nameof(SizeY), sizeY);

        SizeX = sizeX;
        SizeY = sizeY;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return SizeX;
        yield return SizeY;
    }

    public static bool operator ==(Size left, Size right)
        => EqualOperator(left, right);

    public static bool operator !=(Size left, Size right)
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