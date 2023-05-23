namespace Users.Domain.DomainExceptions;

internal class UserHasBeenDeletedException : Exception
{
    public UserHasBeenDeletedException(UserId userId) : base($"User {userId.Value} has been deleted!") { }
}
