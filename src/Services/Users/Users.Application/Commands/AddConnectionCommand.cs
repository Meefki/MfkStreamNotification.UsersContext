using System.Text.Json.Serialization;

namespace Users.Application.Commands;

public class AddConnectionCommand
    : IRequest<bool>
{
    public string UserId { get; set; } = null!;
    public ConnectionDTO Connection { get; set; } = null!;
}

public record ConnectionDTO
{
    [JsonConstructor]
    public ConnectionDTO(
        string id,
        string connectionTo,
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
    public string ConnectionTo { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Scopes { get; set; }
}