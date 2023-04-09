namespace Users.Domain.Aggregates.Users;

public class User : Entity<Guid>, IAggregateRoot
{
    private readonly DateTime _createdDate;
    public DateTime CreatedDate => _createdDate;

    public Credentials Credentials { get; private set; }

    public TwitchUser? TwitchUser { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private User() : base(null!) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public User(
        UserId id,
        Credentials credentials)
        : base(id)
    {
        _createdDate = DateTime.UtcNow;

        // TODO: Add validations for properties below (eg min length, regex for email and etc)
        Credentials = credentials;

        AddUserCreatedDomainEvent(this);
    }

    public void LinkTwitchUser(TwitchUser twitchUser)
    {
        TwitchUser = twitchUser;

        AddTwitchUserLinkedDomainEvent((Id as UserId)!, twitchUser);
    }

    public void UnlinkTwitchUser()
    {
        TwitchUser = null;

        AddTwitchUserUnlinkedDomainEvent((Id as UserId)!);
    }

    // TODO: Domain Events for changing email, login and display name
    #region Domain Events

    private void AddUserCreatedDomainEvent(User user)
    {
        var userCreatedDomainEvent = new UserCreatedDomainEvent(user);

        AddDomainEvent(userCreatedDomainEvent);
    }

    private void AddTwitchUserLinkedDomainEvent(UserId userId, TwitchUser twitchUser)
    {
        var twitchUserLinkedDomainEvent = new TwitchUserLisnkedDomainEvent(userId, twitchUser);

        AddDomainEvent(twitchUserLinkedDomainEvent);
    }

    private void AddTwitchUserUnlinkedDomainEvent(UserId userId)
    {
        var addTwitchUserUnlinkedDomainEvent = new TwitchUserUnlinkedDomainEvent(userId);

        AddDomainEvent(addTwitchUserUnlinkedDomainEvent);
    }

    #endregion
}
