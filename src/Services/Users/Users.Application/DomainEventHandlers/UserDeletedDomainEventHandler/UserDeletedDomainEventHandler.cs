namespace Users.Application.DomainEventHandlers.UserDeletedDomainEventHandler;

internal class UserDeletedDomainEventHandler
    : IDomainEventHandler<UserDeletedDomainEvent>
{
    public async Task Handle(UserDeletedDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        
    }
}
