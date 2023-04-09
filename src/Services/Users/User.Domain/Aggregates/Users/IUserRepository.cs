using Users.Domain.SeedWork;

namespace Users.Domain.Aggregates.Users;

public interface IUserRepository : IRepository<User>
{
    User Add(User user);
    void Update(User user);
    Task<User> GetAsync(Guid userId);
    Task<User> GetAsync(EntityIdentifier<Guid> userId);
}
