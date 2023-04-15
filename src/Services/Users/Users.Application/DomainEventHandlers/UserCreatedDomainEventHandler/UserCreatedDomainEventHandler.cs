namespace Users.Application.DomainEventHandlers.UserCreatedDomainEventHandler;
// TODO: add logging
public class UserCreatedDomainEventHandler 
    : IDomainEventHandler<UserCreatedDomainEvent>
{
    public async Task Handle(UserCreatedDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        
    }
}
