using Subscriptions.Domain.SeedWork;

namespace Subscriptions.Domain.Aggregates;

public record WidgetId : IEntityIdentifier<Guid>
{
    public WidgetId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; protected set; }

    public static WidgetId Create(Guid id)
    {
        return new(id);
    }
}