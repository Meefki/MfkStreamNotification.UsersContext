using Subscriptions.Domain.SeedWork.Mediator;

namespace Subscriptions.Domain.SeedWork;

public interface IEntity
{
    public IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    public void ClearDomainEvents();
}
