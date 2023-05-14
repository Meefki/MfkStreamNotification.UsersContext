using Newtonsoft.Json;

namespace Users.API.Commands;

public class AddConnectionCommand
    : IRequest<bool>
{
    public string UserId { get; set; }
    public ConnectionDTO Connection { get; set; }

    [JsonConstructor]
    public AddConnectionCommand(
        string userId,
        ConnectionDTO connectionDTO)
    {
        UserId = userId;
        Connection = connectionDTO;
    }
}

public record ConnectionDTO
{
    [JsonConstructor]
    public ConnectionDTO(
        string id,
        ConnectionTo connectionTo,
        string login,
        string email,
        string scopes)
    {
        Id = id;
        ConnectionTo = connectionTo;
        Login = login;
        Email = email;
        Scopes = scopes;
    }

    public string Id { get; set; }
    public ConnectionTo ConnectionTo { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Scopes { get; set; }
}