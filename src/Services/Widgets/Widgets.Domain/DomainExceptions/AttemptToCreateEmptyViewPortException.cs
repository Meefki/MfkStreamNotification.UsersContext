using System.Linq;

namespace Subscriptions.Domain.DomainExceptions;

internal class AttemptToCreateEmptyViewPortException
    : Exception
{
    public AttemptToCreateEmptyViewPortException(params string[] emptyArgs) : base($"Attempt to create an empty viewport. Empty args: {string.Join(", ", emptyArgs)}") { }
}
