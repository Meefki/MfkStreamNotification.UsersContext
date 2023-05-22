using Subscriptions.Domain.Aggregates;

namespace Widgets.Domain.DomainExceptions;

internal class AttemptToRemoveNotExistingEventHandler
    : Exception
{
    public AttemptToRemoveNotExistingEventHandler(EventType eventType, Provider provider) 
        : base($"Attemp to remove not existing event handler ({eventType}) from provider ({provider})") { }
}
