namespace Users.Domain.DomainEvents;

/// <summary>
/// Event used when user marked as deleted
/// </summary>
public class UserDeletedDomainEvent : IDomainEvent
{
    public UserId UserId { get; set; }

    public UserDeletedDomainEvent(UserId userId)
    {
        UserId = userId;
    }
}
