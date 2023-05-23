namespace Users.Application.DomainEventHandlers.UserCreatedDomainEventHandler;
// TODO: add logging
public class UserCreatedDomainEventHandler 
    : IDomainEventHandler<UserCreatedDomainEvent>
{
    public Task Handle(UserCreatedDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        //throw new NotImplementedException();
        return Task.CompletedTask;
    }
}
