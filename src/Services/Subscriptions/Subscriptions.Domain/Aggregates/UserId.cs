using Subscriptions.Domain.SeedWork;

namespace Subscriptions.Domain.Aggregates;

public class UserId : IEntityIdentifier<Guid>
{
    public UserId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; protected set; }

    public static UserId Create(Guid id)
    {
        return new UserId(id);
    }
}