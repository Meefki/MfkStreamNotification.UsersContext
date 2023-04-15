using Users.Domain.SeedWork.Mediator;

namespace Users.Domain.SeedWork;

public interface IEntity
{
    public IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    public void ClearDomainEvents();
}
