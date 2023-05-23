namespace Users.Domain.DomainEvents;

/// <summary>
/// Event used when connection added to user
/// </summary>
public class ConnectionAddedDomainEvent : IDomainEvent
{
    public ConnectionAddedDomainEvent(
        UserId userId, 
        Connection twitchUser)
    {
        UserId = userId;
        TwitchUser = twitchUser;
    }

    public UserId UserId { get; set; }
    public Connection TwitchUser { get; set; }
}
