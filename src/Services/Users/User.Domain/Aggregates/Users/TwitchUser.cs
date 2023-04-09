namespace Users.Domain.Aggregates.Users;

public class TwitchUser : Entity<int>
{
    public string Login { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    private string? _scopes;
    public IEnumerable<int> Scopes
    {
        get => ConvertStringScopesToCollection(_scopes);
        private set => _scopes = ConvertCollectionScopesToString(value);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private TwitchUser() : base(null!) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public TwitchUser(
        TwitchUserId id,
        string login,
        string email,
        string password,
        IEnumerable<int> scopes = null!)
        : base(id)
    {
        Login = login;
        Email = email;
        Password = password;
        _scopes = ConvertCollectionScopesToString(scopes);
    }

    private IEnumerable<int> ConvertStringScopesToCollection(string? scopes)
        => scopes is null 
            ? Enumerable.Empty<int>() 
            : scopes
                .Split(',')
                .Select(int.Parse)
                .ToList();

    private string? ConvertCollectionScopesToString(IEnumerable<int> scopes)
        => scopes is null 
            ? null 
            : string.Join(",", scopes);

    public void ProvideScopes(IEnumerable<int> scopes)
        => Scopes = scopes;

    public bool AreScopesProvided()
        => _scopes != null;
}