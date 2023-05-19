namespace Users.Application.DomainEventHandlers.UserDeletedDomainEventHandler;

internal class UserDeletedDomainEventHandler
    : IDomainEventHandler<UserDeletedDomainEvent>
{
    public Task Handle(UserDeletedDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
