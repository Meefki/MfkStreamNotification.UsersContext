using System.Linq;

namespace Subscriptions.Domain.DomainExceptions;

internal class AttemptToCreateEmptyViewPortException
    : Exception
{
    public AttemptToCreateEmptyViewPortException() : base($"Attempt to create an empty viewport") { }
}
