namespace Users.Application.DomainEventHandlers.UserActivatedDomainEventHandler;

public class UserActivatedDomainEventHandler : IDomainEventHandler<UserActivatedDomainEvent>
{
    public async Task Handle(UserActivatedDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        
    }
}
