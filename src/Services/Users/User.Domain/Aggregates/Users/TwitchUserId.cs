namespace Users.Domain.Aggregates.Users;

public record TwitchUserId : IEntityIdentifier<int>
{
    public TwitchUserId(int value)
    {
        Value = value;
    }

    public int Value { get; protected set; }
}
