using User.Domain.SeedWork;

namespace User.Domain.Aggregates.User;

public interface IUserRepository : IRepository<User>
{
    User Add(User user);
    void Update(User user);
    Task<User> GetAsync(Guid userId);
    Task<User> GetAsync(EntityIdentifier<Guid> userId);
}
