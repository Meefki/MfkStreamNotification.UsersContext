namespace Users.Domain.DomainExceptions;

internal class UserIsNotActivatedException : Exception
{
    public UserIsNotActivatedException(UserId userId) : base($"User {userId.Value} is not activated") { }
}
