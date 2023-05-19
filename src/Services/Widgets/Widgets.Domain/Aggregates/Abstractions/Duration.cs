using Subscriptions.Domain.DomainExceptions;
using Subscriptions.Domain.SeedWork;

namespace Subscriptions.Domain.Aggregates.Abstractions;

public class Duration
    : ValueObject
{
    public TimeSpan Value { get; init; }

    public Duration(TimeSpan duration)
    {
        if (duration.TotalMilliseconds < 0)
            throw new InvalidDurationException(duration.TotalMilliseconds);

        Value = duration;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static bool operator ==(Duration left, Duration right)
        => EqualOperator(left, right);

    public static bool operator !=(Duration left, Duration right)
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