namespace Users.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UsersContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public UserRepository(UsersContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public User Add(User user)
    {
        return _context.Users.Add(user).Entity;
    }

    public async Task<User> GetAsync(UserId userId)
    {
        var user = await _context
            .Users
            .Include(u => u.Credentials)
            .FirstOrDefaultAsync(u => (u.Id as UserId) == userId);

        user ??= _context
                .Users
                .Local
                .FirstOrDefault(u => (u.Id as UserId) == userId);

        if (user is not null)
        {
            await _context.Entry(user)
                .Reference(u => u.Connections).LoadAsync();
        }

        return user!;
    }

    public void Update(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
    }
}
