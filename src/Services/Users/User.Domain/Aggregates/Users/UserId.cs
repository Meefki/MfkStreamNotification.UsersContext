namespace Users.Domain.Aggregates.Users;

public record UserId : IEntityIdentifier<Guid>
{
    public UserId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; protected set; }
}
