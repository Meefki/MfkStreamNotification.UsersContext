using Subscriptions.Domain.SeedWork;

namespace Subscriptions.Domain.Aggregates;

public class EventType
    : Enumeration
{
    public static EventType Subscribe => new(1, nameof(Subscribe));
    public static EventType Follow => new(2, nameof(Follow));
    public static EventType Raid => new(3, nameof(Raid));
    public static EventType RewardRedemption => new (4, nameof(RewardRedemption));

    public EventType(int id, string name) : base(id, name)
    {
    }
}