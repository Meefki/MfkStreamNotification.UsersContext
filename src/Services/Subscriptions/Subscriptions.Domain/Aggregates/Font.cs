using Subscriptions.Domain.DomainExceptions;
using Subscriptions.Domain.SeedWork;

namespace Subscriptions.Domain.Aggregates;

public class Font
    : ValueObject
{
    public string Name { get; init; }
    public float Size { get; init; }

    public Font(
        string name,
        float size)
    {
        if (size < 0)
            throw new InvalidFontSizeException(size);

        Name = name;
        Size = size;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Size;
    }

    public static bool operator ==(Font left, Font right)
        => EqualOperator(left, right);

    public static bool operator !=(Font left, Font right)
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