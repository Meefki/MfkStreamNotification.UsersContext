using Subscriptions.Domain.Aggregates;
using Subscriptions.Domain.SeedWork;
using Widgets.Domain.DomainExceptions;

namespace Widgets.Domain.Aggregates;

public class ProviderViewPort
    : Entity<Provider>
{
    private Dictionary<EventType, ViewPort> _eventHanlers;
    public IReadOnlyDictionary<EventType, ViewPort> EventHandlers => _eventHanlers;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private ProviderViewPort() : base(null!) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public ProviderViewPort(
        Provider provider,
        Dictionary<EventType, ViewPort> eventHandlers)
        : base(ProviderViewPortId.Create(provider))
    {
        _eventHanlers = eventHandlers;
    }

    public void AddOrUpdateEventHandler(EventType eventType, ViewPort viewPort)
    {
        _eventHanlers[eventType] = viewPort;
    }

    public void RemoveEventHandler(EventType eventType)
    {
        var existingViewPort = _eventHanlers[eventType];

        if (existingViewPort is null)
            throw new AttemptToRemoveNotExistingEventHandler(eventType, Id.Value);

        _eventHanlers.Remove(eventType);
    }
}
