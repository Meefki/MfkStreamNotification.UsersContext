using System.Runtime.CompilerServices;
using Users.Application.SeedWork.Mediator;

namespace Users.Infrastructure.SeedWork.Mediator;

public static class DomainEventMediatorExtantion
{
    public static async Task DispatchDomainEventsAsync(this IDomainEventMediator mediator, IUserDbContext context, CancellationToken cancellationToken = default)
    {
        var domainEntities = context.ChangeTracker
            .Entries<IEntity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        List<Task> tasks = new();
        foreach (var domainEvent in domainEvents)
            tasks.Add(mediator.Publish(domainEvent, cancellationToken)!);

        await Task.WhenAll(tasks);
    }
}
