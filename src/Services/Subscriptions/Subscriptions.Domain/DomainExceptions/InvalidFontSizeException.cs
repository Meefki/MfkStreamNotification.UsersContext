namespace Subscriptions.Domain.DomainExceptions;

internal class InvalidFontSizeException
    : Exception
{
    public InvalidFontSizeException(float size) : base($"Invalid font size. Value: {size}") { }
}
