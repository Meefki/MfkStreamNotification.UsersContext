namespace Users.Domain.Aggregates.Users;

public record UserId : IEntityIdentifier<Guid>
{
    public UserId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; protected set; }

    public static UserId Create(Guid id)
    {
        return new(id);
    }
}
