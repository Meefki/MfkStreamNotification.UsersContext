namespace Users.Domain.DomainExceptions;

internal class ConnectionAlreadyExistsException : Exception
{
    public ConnectionAlreadyExistsException(ConnectionTo connectionTo) : base($"Connection to {connectionTo.Name} already exists") { }
}
