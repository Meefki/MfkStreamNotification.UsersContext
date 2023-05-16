using Subscriptions.Domain.SeedWork;

namespace Subscriptions.Domain.Aggregates;

public sealed class Widget
    : Entity<Guid>, IAggregateRoot
{
    private WidgetId _id;
    public override IEntityIdentifier<Guid> Id
    { 
        get => _id; 
        protected set => _id = (WidgetId)value;
    }

    public UserId UserId { get; private set; }
    public bool IsUsingDifferentTemplates { get; private set; }

    HashSet<KeyValuePair<Provider, ViewPort>> _eventViewPorts;
    IReadOnlyCollection<KeyValuePair<Provider, ViewPort>> EventViewPorts
        => _eventViewPorts;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Widget() : base(null!) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Widget(
        UserId userId, 
        bool isUsingDifferentTemplates,
        ICollection<KeyValuePair<Provider, ViewPort>> components)
        : base(WidgetId.Create(Guid.NewGuid()))
    {
        _id = (WidgetId)Id;
        UserId = userId;
        IsUsingDifferentTemplates = isUsingDifferentTemplates;
        _eventViewPorts = components.ToHashSet();
    }

    public void ChangeTemplateUsing(bool isUsingDifferentTemplates)
    {
        IsUsingDifferentTemplates = isUsingDifferentTemplates;
    }

    public void AddEventViewPort(Provider provider, ViewPort viewPort)
    {
        _eventViewPorts.Add(new(provider, viewPort));
    }

    public void RemoveEventViewPort(Provider provider, ViewPort viewPort)
    {
        _eventViewPorts.Remove(new(provider, viewPort));
    }
}
