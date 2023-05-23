namespace Users.Domain.DomainEvents;

/// <summary>
/// Event used when account activated
/// </summary>
public class UserActivatedDomainEvent : IDomainEvent
{
    public UserId UserId { get; set; }

    public UserActivatedDomainEvent(UserId userId)
    {
        UserId = userId;
    }
}
