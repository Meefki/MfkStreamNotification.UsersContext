namespace Subscriptions.Domain.SeedWork;

public interface IEntityIdentifier<T>
{
    public T Value { get; }
}
