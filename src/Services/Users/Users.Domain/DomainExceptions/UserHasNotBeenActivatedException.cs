namespace Users.Domain.DomainExceptions;

internal class UserHasNotBeenActivatedException : Exception
{
    public UserHasNotBeenActivatedException(UserId userId) : base($"User {userId.Value} is not activated") { }
}
