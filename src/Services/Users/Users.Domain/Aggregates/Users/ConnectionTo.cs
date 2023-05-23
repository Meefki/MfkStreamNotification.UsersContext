namespace Users.Domain.Aggregates.Users;

public class ConnectionTo
    : Enumeration
{
    public static ConnectionTo Twitch = new(1, nameof(Twitch));
    public static ConnectionTo YouTube = new(2, nameof(YouTube));
    public static ConnectionTo Trovo = new(3, nameof(Trovo));

    public ConnectionTo(int id, string name) 
        : base(id, name)
    {
    }
}
