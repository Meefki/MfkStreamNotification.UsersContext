namespace Users.Application.SeedWork.Mediator;

public interface IDomainEventMediator
{
    //Task DispatchDomainEventsAsync(IUserDbContext context, CancellationToken cancellationToken = default);
    void Register<T>(IDomainEventHandler<T> handler) where T : IDomainEvent;
    Task Publish<T>(T domainEvent, CancellationToken cancellationToken = default) where T : IDomainEvent;
}
