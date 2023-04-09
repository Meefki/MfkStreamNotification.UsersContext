namespace Users.Infrastructure;

public class UsersContext : DbContext, IUnitOfWork
{
    public const string DEFAULT_SCHEMA = "users";

    DbSet<User> Users { get; set; }
    
    private IDbContextTransaction? _currentTransaction;

    public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }

    public IDbContextTransaction? GetCurrentTransaction() => _currentTransaction;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TwitchUserEntityTypeConfiguration());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        // Dispatch domain events

        var result = await base.SaveChangesAsync(cancellationToken);

        return true;
    }
}
