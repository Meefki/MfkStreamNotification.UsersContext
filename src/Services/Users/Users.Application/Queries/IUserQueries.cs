namespace Users.Application.Queries;

public interface IUserQueries
{
    public Task<UserDto> GetUserAsync(Guid userId);
}
