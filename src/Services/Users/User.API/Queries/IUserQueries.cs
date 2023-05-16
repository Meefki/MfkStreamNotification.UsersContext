namespace Users.API.Queries;

public interface IUserQueries
{
    public Task<User> GetUserAsync(Guid userId);
}
