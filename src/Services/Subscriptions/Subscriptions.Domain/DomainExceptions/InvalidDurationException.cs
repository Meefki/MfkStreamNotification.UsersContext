namespace Subscriptions.Domain.DomainExceptions;

internal class InvalidDurationException
    : Exception
{
    public InvalidDurationException(double value) : base($"Invalid duration! Should be more than 0. Current value: {value}") { }
}
