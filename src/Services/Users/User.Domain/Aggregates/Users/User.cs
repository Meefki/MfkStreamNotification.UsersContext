using Users.Domain.DomainExceptions;

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

    private List<Connection> _connections;
    public IReadOnlyCollection<Connection> Connections => _connections.AsReadOnly();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private User() : base(null!) { _connections = new(); }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public User(
        Credentials credentials, 
        ICollection<Connection>? connections = null)
        : base(new UserId(Guid.NewGuid()))
    {
        _id = (UserId)Id;
        _createdDate = DateTime.UtcNow;
        IsActive = false;
        IsDeleted = false;

        _connections = connections?.ToList() ?? new();

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

    public void AddConnection(Connection connection)
    {
        if (!IsActive)
            throw new UserIsNotActivatedException(_id);

        if (_connections.Select(c => c.ConnectionTo).Contains(connection.ConnectionTo))
            throw new ConnectionAlreadyExistsException(connection.ConnectionTo);

        _connections.Add(connection);

        AddConnectionAddedDomainEvent(_id, connection);
    }

    public void RemoveConnection(ConnectionTo connectionTo)
    {
        if (!IsActive)
            throw new UserIsNotActivatedException(_id);

        if (!_connections.Select(c => c.ConnectionTo).Contains(connectionTo))
            throw new ConnectionIsNotExistException(connectionTo);

        _connections.Remove(_connections.First(c => c.ConnectionTo == connectionTo));

        AddConnectionRemovedDomainEvent(_id, connectionTo);
    }

    // TODO: Domain Events for changing email, login and display name
    #region Domain Events

    private void AddUserCreatedDomainEvent(User user)
    {
        var userCreatedDomainEvent = new UserCreatedDomainEvent(user);

        AddDomainEvent(userCreatedDomainEvent);
    }

    private void AddConnectionAddedDomainEvent(UserId userId, Connection twitchUser)
    {
        var twitchUserLinkedDomainEvent = new ConnectionAddedDomainEvent(userId, twitchUser);

        AddDomainEvent(twitchUserLinkedDomainEvent);
    }

    private void AddConnectionRemovedDomainEvent(UserId userId, ConnectionTo connectionTo)
    {
        var twitchUserUnlinkedDomainEvent = new ConnectionRemovedDomainEvent(userId, connectionTo);

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
