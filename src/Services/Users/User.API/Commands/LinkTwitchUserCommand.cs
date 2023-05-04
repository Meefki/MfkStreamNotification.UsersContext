using Newtonsoft.Json;

namespace Users.API.Commands;

public class LinkTwitchUserCommand
    : IRequest<bool>
{
    public string UserId { get; set; }
    public TwitchUserDTO TwitchUser { get; set; }

    [JsonConstructor]
    public LinkTwitchUserCommand(
        string userId,
        TwitchUserDTO twitchUserDTO)
    {
        UserId = userId;
        TwitchUser = twitchUserDTO;
    }
}

public record TwitchUserDTO
{
    [JsonConstructor]
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