namespace Users.API.Commands;

public class RestoreUserCommand
    : IRequest<bool>
{
    public string UserId { get; set; }

    public RestoreUserCommand(string userId)
    {
        UserId = userId;
    }
}
