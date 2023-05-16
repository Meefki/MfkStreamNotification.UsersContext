namespace Subscriptions.Domain.DomainExceptions;

internal class InvalidSizeException
    : Exception
{
    public InvalidSizeException(string propName, float value) : base($"invalid value of size. Axis: {propName}, value: {value}") { }
}
