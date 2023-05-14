namespace Users.Domain.Aggregates.Users;

public class Connection : Entity<Guid>
{
    public ConnectionTo ConnectionTo { get; private set; }
    public string UserId { get; private set; }
    public string Login { get; private set; }
    public string Email { get; private set; }
    public bool AreScopesProvided => _scopes != null;

    private string? _scopes;
    public IEnumerable<int> Scopes
    {
        get => ConvertStringScopesToCollection(_scopes);
        private set => _scopes = ConvertCollectionScopesToString(value);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Connection() : base(null!) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Connection(
        ConnectionId id,
        ConnectionTo connectionTo,
        string userId,
        string login,
        string email,
        IEnumerable<int> scopes = null!,
        string scopeString = null!)
        : base(id)
    {
        ConnectionTo = connectionTo;
        UserId = userId;
        Login = login;
        Email = email;

        if (scopes == null && scopeString != null)
            _scopes = scopeString;
        if (scopeString == null && scopes != null)
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
}