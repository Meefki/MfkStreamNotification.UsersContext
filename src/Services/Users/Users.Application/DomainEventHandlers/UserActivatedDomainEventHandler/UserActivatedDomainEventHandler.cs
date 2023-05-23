namespace Users.Application.DomainEventHandlers.UserActivatedDomainEventHandler;

public class UserActivatedDomainEventHandler : IDomainEventHandler<UserActivatedDomainEvent>
{
    public Task Handle(UserActivatedDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        //throw new NotImplementedException();
        return Task.CompletedTask;
    }
}
