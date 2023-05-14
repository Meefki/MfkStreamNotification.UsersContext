namespace Users.Domain.DomainEvents;

/// <summary>
/// Event used when connection removed from user
/// </summary>
public class ConnectionRemovedDomainEvent : IDomainEvent
{
    public ConnectionRemovedDomainEvent(
        UserId userId,
        ConnectionTo connectionTo)
    {
        UserId = userId;
        ConnectionTo = connectionTo;
    }

    public UserId UserId { get; set; }
    public ConnectionTo ConnectionTo { get; set; }
}
