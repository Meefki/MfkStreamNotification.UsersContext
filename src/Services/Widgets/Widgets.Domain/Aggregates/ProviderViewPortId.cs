using Subscriptions.Domain.Aggregates;
using Subscriptions.Domain.SeedWork;

namespace Widgets.Domain.Aggregates;

public class ProviderViewPortId
    : ValueObject, IEntityIdentifier<Provider>
{
    public static ProviderViewPortId Create(Provider provider) => new(provider);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public ProviderViewPortId(Provider provider)
    {
        Value = provider;
    }

    public Provider Value { get; init; }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode() 
    {
        return base.GetHashCode();
    }

    public static bool operator ==(ProviderViewPortId left, ProviderViewPortId right)
        => EqualOperator(left, right);

    public static bool operator !=(ProviderViewPortId left, ProviderViewPortId right)
        => NotEqualOperator(left, right);

    public static bool operator ==(ProviderViewPortId left, Provider right)
        => EqualOperator(left, Create(right));

    public static bool operator !=(ProviderViewPortId left, Provider right)
        => NotEqualOperator(left, Create(right));
}
