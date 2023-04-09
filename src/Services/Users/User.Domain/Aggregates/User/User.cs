using User.Domain.SeedWork;

namespace User.Domain.Aggregates.User;

public class User : Entity<Guid>, IAggregateRoot
{
    private readonly DateTime _createdDate;
    public DateTime CreatedDate => _createdDate;

    public string DisplayName { get; private set; }
    public string Login { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public TwitchUser? TwitchUser { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private User() : base(null!) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public User(
        Guid id, 
        string displayName, 
        string login, 
        string password,
        string email)
        : base(new(id))
    {
        _createdDate = DateTime.UtcNow;

        // TODO: Add validations for properties below (eg min length, regex for email and etc)
        DisplayName = displayName;
        Login = login;
        Password = password;
        Email = email;

        // TODO: UserCreatedDomainEvent
    }

    public void LinkTwitchUser(TwitchUser twitchUser)
    {
        TwitchUser = twitchUser;

        // TODO: TwitchUserLinkedDomainEvent
    }

    public void UnlinkTwitchUser()
    {
        TwitchUser = null;

        // TODO: TwitchUserUnlinkedDomainEvent
    }

    // TODO: Domain Events for changing email, login and display name
}
