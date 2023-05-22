using Subscriptions.Domain.Aggregates;

namespace Widgets.Domain.DomainExceptions;

internal class UnsupportedProviderException
    : Exception
{
    public UnsupportedProviderException(bool isSingleTemplateUsing, Provider provider) : base($"Unsupported provider ({provider}) for operation. " +
        $"Is single template used: {isSingleTemplateUsing}") { }
}
