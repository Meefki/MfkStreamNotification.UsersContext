namespace Subscriptions.Domain.DomainExceptions;

internal class InvalidPercentsRangeException
    : Exception
{
    public InvalidPercentsRangeException(int value, int minValue, int maxValue) 
        : base($"Invalid percents rande! Should be more than {minValue} and less than {maxValue}. Current value: {value}") { }
}
