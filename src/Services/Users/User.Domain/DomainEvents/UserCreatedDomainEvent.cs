namespace Users.Domain.DomainEvents;

/// <summary>
/// Event used when a user is created
/// </summary>
public class UserCreatedDomainEvent : IDomainEvent
{
    public UserCreatedDomainEvent(
        User user)
    {
        User = user;
    }

    public User User { get; set; }
}
