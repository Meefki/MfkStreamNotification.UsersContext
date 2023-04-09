using User.Domain.SeedWork;

namespace User.Domain.Aggregates.User;

public class TwitchUser : Entity<int>
{
    public string Login { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    private string _scopes;
    public IEnumerable<int> Scopes 
    {
        get => ConvertStringScopesToCollection(_scopes);
        private set => _scopes = ConvertCollectionScopesToString(value);
    }

    public TwitchUser(
        int id,
        string login,
        string email,
        string password,
        IEnumerable<int> scopes = null!)
        : base(new(id))
    {
        Login = login;
        Email = email;
        Password = password;
        _scopes = ConvertCollectionScopesToString(scopes);
    }

    private IEnumerable<int> ConvertStringScopesToCollection(string scopes)
    {
        return scopes
            .Split(',')
            .Select(int.Parse)
            .ToList() ?? Enumerable.Empty<int>();
    }

    private string ConvertCollectionScopesToString(IEnumerable<int> scopes)
    {
        return scopes is null ? "" : string.Join(",", scopes);
    }

    public void ProvideScopes(IEnumerable<int> scopes)
    {
        Scopes = scopes;
    }
}