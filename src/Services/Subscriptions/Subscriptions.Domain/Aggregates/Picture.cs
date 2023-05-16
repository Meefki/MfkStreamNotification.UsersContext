using Subscriptions.Domain.Aggregates.Abstractions;

namespace Subscriptions.Domain.Aggregates;

public class Picture
    : ComponentVO
{
    public static Picture CreateEmpty()
        => new(new(0, 0), new(0, 0), new(new(0)), string.Empty, RenderType.NoTransform);

    public string Url { get; init; }
    public RenderType RenderType { get; init; }

    public Picture(
        Position position, 
        Size size, 
        Duration duration,
        string url,
        RenderType renderType) 
        : base(position, size, duration)
    {
        Url = url;
        RenderType = renderType;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return base.GetEqualityComponents();

        yield return Url;
        yield return RenderType;
    }

    public static bool operator ==(Picture left, Picture right)
        => EqualOperator(left, right);

    public static bool operator !=(Picture left, Picture right)
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