using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Users.Infrastructure;

public interface IUserDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<TwitchUser> TwitchUsers { get; set; }
    ChangeTracker ChangeTracker { get; }
}
