namespace Users.Domain.DomainEvents;

/// <summary>
/// Event used when twitch user linked to user
/// </summary>
public class TwitchUserLisnkedDomainEvent : IDomainEvent
{
    public TwitchUserLisnkedDomainEvent(
        UserId userId, 
        TwitchUser twitchUser)
    {
        UserId = userId;
        TwitchUser = twitchUser;
    }

    public UserId UserId { get; set; }
    public TwitchUser TwitchUser { get; set; }
}
