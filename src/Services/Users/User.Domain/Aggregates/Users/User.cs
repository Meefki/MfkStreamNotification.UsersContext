namespace Users.Domain.Aggregates.Users;

public class User : Entity<Guid>, IAggregateRoot
{
    private UserId _id;
    public override IEntityIdentifier<Guid> Id
    {
        get => _id;
        protected set => _id = (UserId)value;
    }

    private readonly DateTime _createdDate;
    public DateTime CreatedDate => _createdDate;

    public Credentials Credentials { get; private set; }

    public bool IsActive { get; private set; }
    public bool IsDeleted { get; private set; }

    public TwitchUser? TwitchUser { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private User() : base(null!) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public User(
        Credentials credentials)
        : base(new UserId(Guid.NewGuid()))
    {
        _id = (UserId)Id;
        _createdDate = DateTime.UtcNow;
        IsActive = false;
        IsDeleted = false;

        // TODO: Add validations for properties below (eg min length, regex for email and etc)
        Credentials = credentials;

        AddUserCreatedDomainEvent(this);
    }

    public void ActivateUser()
    {
        if (!IsActive)
        {
            IsActive = true;

            AddUserActivatedDomainEvent(_id);
        }
    }

    public void DeleteUser()
    {
        if (!IsDeleted)
        {
            IsDeleted = true;

            AddUserDeletedDomainEvent(_id);
        }
    }

    public void RestoreUser()
    {
        if (IsDeleted)
        {
            IsDeleted = false;

            AddUserRestoredDomainEvent(_id);
        }
    }

    public void LinkTwitchUser(TwitchUser twitchUser)
    {
        TwitchUser = twitchUser;

        AddTwitchUserLinkedDomainEvent(_id, twitchUser);
    }

    public void UnlinkTwitchUser()
    {
        TwitchUser = null;

        AddTwitchUserUnlinkedDomainEvent(_id);
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
        var twitchUserUnlinkedDomainEvent = new TwitchUserUnlinkedDomainEvent(userId);

        AddDomainEvent(twitchUserUnlinkedDomainEvent);
    }

    private void AddUserActivatedDomainEvent(UserId userId)
    {
        var userActivatedDomainEvent = new UserActivatedDomainEvent(userId);

        AddDomainEvent(userActivatedDomainEvent);
    }

    private void AddUserDeletedDomainEvent(UserId userId)
    {
        var userDeletedDomainEvent = new UserDeletedDomainEvent(userId);

        AddDomainEvent(userDeletedDomainEvent);
    }

    private void AddUserRestoredDomainEvent(UserId userId)
    {
        var userRestoredDomainEvent = new UserRestoredDomainEvent(userId);

        AddDomainEvent(userRestoredDomainEvent);
    }

    #endregion
}
