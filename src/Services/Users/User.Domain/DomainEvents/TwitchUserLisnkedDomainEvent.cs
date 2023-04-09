namespace Users.Domain.DomainEvents;

/// <summary>
/// Event used when a twitch user is linked to a user
/// </summary>
public class TwitchUserLisnkedDomainEvent : IDomainEvent
{
    public TwitchUserLisnkedDomainEvent(
        EntityIdentifier<Guid> userId, 
        TwitchUser twitchUser)
    {
        UserId = userId;
        TwitchUser = twitchUser;
    }

    public EntityIdentifier<Guid> UserId { get; set; }
    public TwitchUser TwitchUser { get; set; }
}
