using Subscriptions.Domain.SeedWork;
using Widgets.Domain.Aggregates;
using Widgets.Domain.DomainExceptions;

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
    public bool IsSingleTemplateUsing { get; private set; }

    List<ProviderViewPort> _providerViewPorts;
    IReadOnlyCollection<ProviderViewPort> ProviderViewPorts
        => _providerViewPorts;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Widget() : base(null!) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private Widget(
        UserId userId,
        bool isSingleTemplateUsed,
        ICollection<ProviderViewPort> components)
        : base(WidgetId.Create(Guid.NewGuid()))
    {
        _id = (WidgetId)Id;
        UserId = userId;
        IsSingleTemplateUsing = isSingleTemplateUsed;
        _providerViewPorts = components.ToList();
    }

    public void ChangeTemplatesUsing(bool isSingleTemplateUsing)
    {
        IsSingleTemplateUsing = isSingleTemplateUsing;
    }

    public void AddEventViewPortToProvider(ProviderViewPort providerViewPort)
    {
        if (IsSingleTemplateUsing && providerViewPort.Id != Provider.Common)
            throw new UnsupportedProviderException(IsSingleTemplateUsing, providerViewPort.Id.Value);

        _providerViewPorts.Add(providerViewPort);
    }

    public void RemoveEventViewPortFromProvider(ProviderViewPort providerViewPort)
    {
        if (IsSingleTemplateUsing && providerViewPort.Id != Provider.Common)
            throw new UnsupportedProviderException(IsSingleTemplateUsing, providerViewPort.Id.Value);

        _providerViewPorts.Remove(providerViewPort);
    }

    public static Widget Create(
        UserId userId,
        bool isSingleTemplateUsed,
        ICollection<ProviderViewPort> providerViewPorts)
    {
        return new(userId, isSingleTemplateUsed, providerViewPorts);
    }
}
