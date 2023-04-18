namespace Users.API.Commands;

public class LinkTwitchUserCommand
    : IRequest<bool>
{
    public string UserId { get; set; }
    public TwitchUserDTO TwitchUser { get; set; }

    public LinkTwitchUserCommand(
        string userId,
        int twitchUserId,
        string twtichUserLogin,
        string twitchUserEmail,
        string twitchUserScopes)
    {
        UserId = userId;
        TwitchUser = new(
            twitchUserId, 
            twtichUserLogin, 
            twitchUserEmail, 
            twitchUserScopes);
    }
}

public record TwitchUserDTO
{
    public TwitchUserDTO(
        int id,
        string login,
        string email,
        string scopes)
    {
        Id = id;
        Login = login;
        Email = email;
        Scopes = scopes;
    }

    public int Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Scopes { get; set; }
}