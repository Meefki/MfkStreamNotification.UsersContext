using Subscriptions.Domain.SeedWork;

namespace Subscriptions.Domain.Aggregates.Abstractions;

public abstract class ComponentVO
    : ValueObject
{
    public ComponentVO(
        Position position,
        Size size,
        Duration duration)
    {
        Position = position;
        Size = size;
        Duration = duration;
    }

    public Position Position { get; init; }
    public Size Size { get; set; }
    public Duration Duration { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Position;
        yield return Size;
        yield return Duration;
    }
}