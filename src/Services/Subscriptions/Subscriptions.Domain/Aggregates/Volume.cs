using Subscriptions.Domain.DomainExceptions;
using Subscriptions.Domain.SeedWork;

namespace Subscriptions.Domain.Aggregates;

public class Volume
    : ValueObject
{
    private const int max_percents_range = 200;
    private const int min_percents_range = 0;

    public int Percents { get; init; }
    public float Multiplier => Percents / 100f;

    public Volume(int percents)
    {
        if (percents > max_percents_range || percents < min_percents_range)
            throw new InvalidPercentsRangeException(percents, min_percents_range, max_percents_range);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Percents;
    }
}