namespace Users.Application.Queries;

public interface IUserQueries
{
    public Task<User> GetUserAsync(Guid userId);
}
