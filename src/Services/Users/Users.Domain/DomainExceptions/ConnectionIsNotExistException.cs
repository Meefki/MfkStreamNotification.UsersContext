namespace Users.Domain.DomainExceptions;

internal class ConnectionIsNotExistException : Exception
{
    public ConnectionIsNotExistException(ConnectionTo connectionTo) : base($"Connection {connectionTo.Name} is not exist") { }
}
