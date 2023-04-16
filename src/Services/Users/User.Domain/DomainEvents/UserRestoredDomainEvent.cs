namespace Users.Domain.DomainEvents;

/// <summary>
/// Event used when user restored
/// </summary>
public class UserRestoredDomainEvent : IDomainEvent
{
    public UserId UserId { get; set; }

    public UserRestoredDomainEvent(UserId userId)
    {
        UserId = userId;
    }
}
