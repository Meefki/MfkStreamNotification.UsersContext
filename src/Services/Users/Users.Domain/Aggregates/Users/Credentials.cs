namespace Users.Domain.Aggregates.Users;

public class Credentials
    : ValueObject
{
    public string DisplayName { get; init; } 
    public string Login { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }

    public Credentials(
        string displayName,
        string login,
        string email, // TODO: value object
        string password)
    {
        DisplayName = displayName;
        Login = login; 
        Email = email; 
        Password = password;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return DisplayName;
        yield return Login;
        yield return Email;
        yield return Password;
    }

    public static bool operator ==(Credentials left, Credentials right) 
        => EqualOperator(left, right);

    public static bool operator !=(Credentials left, Credentials right)
        => NotEqualOperator(left, right);

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
