using Subscriptions.Domain.Aggregates.Abstractions;
using System;

namespace Subscriptions.Domain.Aggregates;

public class Audio
    : ComponentVO
{
    public static Audio CreateEmpty()
        => new(new(0, 0), new(0, 0), new(new(0)), string.Empty, new(0), PlayType.Single);

    public string Url { get; init; }
    public Volume Volume { get; init; }
    public PlayType PlayType { get; init; }

    public Audio(
        Position position, 
        Size size, 
        Duration duration,
        string url,
        Volume volume,
        PlayType playType) 
        : base(position, size, duration)
    {
        Url = url;
        Volume = volume;
        PlayType = playType;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return base.GetEqualityComponents();

        yield return Url;
        yield return Volume;
        yield return PlayType;
    }

    public static bool operator ==(Audio left, Audio right)
        => EqualOperator(left, right);

    public static bool operator !=(Audio left, Audio right)
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