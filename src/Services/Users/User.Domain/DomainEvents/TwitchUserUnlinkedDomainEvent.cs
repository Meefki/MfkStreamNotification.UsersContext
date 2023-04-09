namespace Users.Domain.DomainEvents;

/// <summary>
/// Event used when a twitch user is unlinked from a user
/// </summary>
public class TwitchUserUnlinkedDomainEvent : IDomainEvent
{
    public TwitchUserUnlinkedDomainEvent(EntityIdentifier<Guid> userId) // TODO: think about how to put type of id dynamically and get right type in the handlers
    {
        UserId = userId;
    }

    public EntityIdentifier<Guid> UserId { get; set; }
}
