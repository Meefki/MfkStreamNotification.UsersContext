namespace Users.Domain.Aggregates.Users;

public record ConnectionId : IEntityIdentifier<Guid>
{
    public ConnectionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; protected set; }
}
