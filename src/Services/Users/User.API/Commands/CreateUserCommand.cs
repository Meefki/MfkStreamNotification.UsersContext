namespace Users.API.Commands;

public class CreateUserCommand
    : IRequest<bool>
{
    [DataMember] public string Login { get; private set; }
    [DataMember] public string Email { get; private set; }
    [DataMember] public string Password { get; private set; }
    [DataMember] public string DisplayName { get; private set; }

    public CreateUserCommand(
        string login,
        string email,
        string password,
        string displayName)
    {
        Login = login;
        Email = email;
        Password = password;
        DisplayName = displayName;
    }
}
